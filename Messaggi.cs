namespace RemoDome
{
    public static class Messaggi
    {
        public static DialogResult ShowError(string messaggio)
        {
            return MessageBox.Show(messaggio, "Cupola Remota", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Show(string messaggio)
        {
            return MessageBox.Show(messaggio, "Cupola Remota", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static DialogResult YesNo(string messaggio)
        {
            return MessageBox.Show(messaggio, "Cupola Remota", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowWarning(string messaggio)
        {
            return MessageBox.Show(messaggio, "Cupola Remota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowException(string messaggio, Exception ex)
        {
            return MessageBox.Show(messaggio + " " + ex.Message, "Cupola Remota", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}