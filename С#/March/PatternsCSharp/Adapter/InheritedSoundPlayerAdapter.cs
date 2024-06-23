using PatternsCSharp.Adapter;
using System.Media;

public class InheritedSoundPlayerAdapter : SoundPlayer, IAudioPlayer
{
    public void Load(string fileName)
    {
        SoundLocation = fileName;
        Load();
    }
}