using PatternsCSharp.Adapter;
using System.Media;

public class SoundPlayerAdapter : IAudioPlayer
{
    private readonly SoundPlayer soundPlayer;

    public SoundPlayerAdapter(SoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer;
    }
    public void Load(string fileName)
    {
        soundPlayer.SoundLocation = fileName;
        soundPlayer.Load();
    }
    public void Play()
    {
        soundPlayer.Play();
    }

    public void Stop()
    {
        soundPlayer.Stop();
    }
}
