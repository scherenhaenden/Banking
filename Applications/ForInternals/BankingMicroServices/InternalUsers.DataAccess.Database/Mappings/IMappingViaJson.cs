using Newtonsoft.Json;

namespace InternalUsers.DataAccess.Database.Mappings;

public interface IMappingViaJson
{
    Output Map<Output, Input>(Input obj);
    
    Output Map<Output>(object obj);
}

public class MappingViaJson: IMappingViaJson
{
    public Output Map<Output, Input>(Input obj)
    {
        // Create settings for JSON serialization.
        var settings = new JsonSerializerSettings
        {
            //TypeNameHandling = TypeNameHandling.All
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
        
        // Create JSON serializer using the settings from above
        var serializer = JsonSerializer.Create(settings);
        
        
        // Parse object to json using the serializer
        var json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        
        // Parse json to object using the serializer
        var output = JsonConvert.DeserializeObject<Output>(json, settings);
        
        return output;
    }

    public Output Map<Output>(object obj)
    {
        // Create settings for JSON serialization.
        var settings = new JsonSerializerSettings
        {
            //TypeNameHandling = TypeNameHandling.All
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
        
        // Create JSON serializer using the settings from above
        var serializer = JsonSerializer.Create(settings);
        
        
        // Parse object to json using the serializer
        var json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        
        // Parse json to object using the serializer
        var output = JsonConvert.DeserializeObject<Output>(json, settings);
        
        return output;
    }
}

