using System.Windows.Forms;

namespace NotePadAdapter
{
    public interface IAdapter
    {
        /// <summary>
        /// Used to Register Event Handler to your Tool Strip menu items
        /// </summary>
        /// <param name="item">ToolStripMenuItem</param>
        /// <param name="eventHandler">Event</param>
        void RegisterClickHandler(ToolStripMenuItem item, Event eventHandler);
    }
}
