namespace GIFBuilder
{
    class GIFBuilderTool : ITool
    {
        public void Execute(params object[] args)
        {
            GIFBuilderUI gifBuilderUI = new GIFBuilderUI();
            gifBuilderUI.ShowDialog();
        }

        public string Name
        {
            get { return "GIF Builder"; }
        }

        public string Description
        {
            get { return "Helps to create GIF files from Images"; }
        }

        public string MenuCaption
        {
            get { return "GIF生成"; }
        }

        public bool IsVisible
        {
            get { return true; }
        }
    }
}
