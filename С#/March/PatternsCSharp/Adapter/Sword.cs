using PatternsCSharp.Adapter;

public class Sword : IWeapon
{
    private readonly int damage;

    public Sword(int damage)
    {
        this.damage = damage;
    }
    public void Hit(Player player)
    {
        player.ApplyDamage(damage);
    }
}
