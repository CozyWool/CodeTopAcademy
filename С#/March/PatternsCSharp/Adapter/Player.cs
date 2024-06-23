using PatternsCSharp.Adapter;

public class Player
{
    private int Health { get; set; }
    private IWeapon _weapon;

    public Player(IWeapon weapon, int health)
    {
        _weapon = weapon;
        Health = health;
    }

    internal IWeapon Weapon { get => _weapon; set => _weapon = value; }

    public void ApplyDamage(int damage)
    {
        if (Health <= 0) { return; }
        Health -= damage;
    }
    public void ChangeWeapon(IWeapon weapon)
    {
        Weapon = weapon;
    }
}
