using System.Windows.Forms;

namespace Tank_Game
{
	public partial class Guide : Form
	{

		public Guide()
		{
			InitializeComponent();
			string summary = "This is a 2 player keyboard game. \n" +
				"Each Player controls a tank, and the goal is to \n" +
				"Shoot the other player with bullets to score points!\n" +
				"You both are inside a maze of sorts that changes.\n" +
				"Be Careful when shooting! you will quickly learn that \n" +
				"bullets bounce." +
				"\n" +
				"\n" +
				"You can control your tanks with the keys shown below.\n" +
				"You can move in all directions, with a combination of up /\n" +
				"down and left/right. You can only shoot 9 bullets at a \n" +
				"time, so dont go guns ablazing willy nilly.. \n" +
				"Have Fun.";
			labelSummary.Text = summary;
		}
	}
}
