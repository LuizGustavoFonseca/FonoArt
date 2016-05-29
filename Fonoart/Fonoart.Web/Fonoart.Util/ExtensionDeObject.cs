using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

public static class ExtensionsDeObject
{
    public static TRetorno Clonar<TRetorno>(this object instancia) where TRetorno : class
    {
        using (var stream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter(
                null,
                new StreamingContext(StreamingContextStates.Clone)
            );
            formatter.Serialize(stream, instancia);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as TRetorno;
        }
    }

    public static TSaida TransformarEm<TSaida>(this object instancia) where TSaida : class
    {
        return Mapper.Map<TSaida>(instancia, options =>
        {            
            options.DisableCache = true;
        });
    }

    public static TSaida[] TransformarEmListaDe<TSaida>(this IEnumerable<object> instancias) where TSaida : class
    {
        return instancias.Select(i => i.TransformarEm<TSaida>()).ToArray();
    }
    
}
