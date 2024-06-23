using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace _12._09_HW;

[Flags]
public enum KeyFlags
{
    None = 0,
    Ctrl = 1,
    LeftMouse = 2,
    CtrlAndLeftMouse = Ctrl | LeftMouse
}
public partial class Task3Form : Form
{
    private KeyFlags _keyFlags;
    private bool _inBorder;
    private bool _inRectangle;
    public Task3Form()
    {
        InitializeComponent();
        Text = $"Ширина = {Cursor.Position.X}, Высота = {Cursor.Position.Y}";
    }

    private void Task3Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control) _keyFlags |= KeyFlags.Ctrl;
        Debug.WriteLine(_keyFlags);
        if (IsCloseApp()) Close();
    }

    private void Task3Form_MouseDown(object sender, MouseEventArgs e)
    {
        // Надо было сделать изменение заголовка окна, но оно и так меняется при перемещении курсора
        if (e.Button == MouseButtons.Right) MessageBox.Show($"Ширина = {e.Location.X}, Высота = {e.Location.Y}");
        if (e.Button == MouseButtons.Left)
        {
            _keyFlags |= KeyFlags.LeftMouse;
            if (!_inBorder && !_inRectangle) MessageBox.Show("Вне прямоугольника");
        }
        Debug.WriteLine(_keyFlags);
        if (IsCloseApp()) Close();
    }
    private bool IsCloseApp() => _keyFlags == KeyFlags.CtrlAndLeftMouse;
    private void Task3Form_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) _keyFlags -= KeyFlags.LeftMouse;
    }

    private void Task3Form_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Control) _keyFlags -= KeyFlags.Ctrl;
    }

    private void Rectangle_Click(object sender, EventArgs e)
    {
        if (_inRectangle)
        {
            MessageBox.Show("Внутри прямоугольника");
        }
    }

    private void Border_MouseEnter(object sender, EventArgs e)
    {
        _inBorder = true;
    }

    private void Border_MouseLeave(object sender, EventArgs e)
    {
        _inBorder = false;
    }

    private void Rectangle_MouseEnter(object sender, EventArgs e)
    {
        _inRectangle = true;
        _inBorder = false;
    }

    private void Rectangle_MouseLeave(object sender, EventArgs e)
    {
        _inRectangle = false;
    }

    private void Border_Click(object sender, EventArgs e)
    {
        if (_inBorder)
        {
            MessageBox.Show("На границе прямоугольника");
        }
    }


    private void Task3Form_MouseMove(object sender, MouseEventArgs e)
    {
        Text = $"Ширина = {Cursor.Position.X}, Высота = {Cursor.Position.Y}";
    }
}
