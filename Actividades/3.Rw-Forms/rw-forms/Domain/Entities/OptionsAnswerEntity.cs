using System.Text.Json;
namespace RWFormsApi.Domain.Entities;

public class OptionsAnswerEntity : IAnswer
{
    public List<OptionEntity> Options { get; set; } = new List<OptionEntity>();

    public OptionsAnswerEntity()
    {
        Options = new List<OptionEntity>();
    }

    public OptionsAnswerEntity(IEnumerable<string> optionsString)
    {
        foreach (var option in optionsString)
        {
            Options.Add(new OptionEntity(){Value = option, IsSelected = false});
        } 
    }

    public override IAnswer CreateAnswer(object data)
    {
        string dataString = data.ToString() ?? "";
        
        List<string> options = JsonSerializer.Deserialize<List<string>>(dataString) ?? throw new Exception("Error : Data is not valid for answer options.");

        return new OptionsAnswerEntity(options);
    }
}
