using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace FileSQZ
{
	class CompressorClass
	{
		//Globals for storing text/binary data
		string wholeFile = "";
		Queue<int> binQue = new Queue<int> ();
		Queue<byte> ByteQue= new Queue<byte> ();


		public void codeTxt ()
		{
			/*
			//vars for converting chars to custom binary
			string a = 0
			string b = 1;
			string c = 2;
			string d = 3;
			string e = 4;
			string f = 5;
			string g = 6;
			string h = 7;
			string i = 8;
			string j = 9;
			string l = 10;
			string m = 11;
			string n = 12;
			string o = 13;
			string p = 14;
			string r = 15;
			string s = 16;
			string t = 17;
			string u = 18;
			string v = 19;
			string w = 20;
			string y = 21;
			string charSpace = 22;
			string charQuotes = 23;
			string z = 24;
			string x = 25;
			string k = 26;
			string charPer = 27;
			string q = 28;
			string charQuest = 29;
			string charEx = 30;

			//vars for chop page conversion to binary
			string one = 0;
			string two = 1;
			string three = 2;
			string four = 3;
			string five = 4;
			string six = 5;
			string seven = 6;
			string eight = 7;
			string nine = 8;
			string zero = 9;
			string charSpace2 = 10;
			*/

			//////////////////////////////////////////////////////////////////////////
			//var for reading lines from original file
			string line = "";
			int queCount = 0;
			int tempInt = 0;
			byte tempByte = 0;

			//Reads in book
			using (StreamReader sr = new StreamReader ("Frank.txt")) {
				while ((line = sr.ReadLine ()) != null) {
					wholeFile = wholeFile + line;
				}
			}
			wholeFile.ToLower ();
			Console.WriteLine ("File Read!");

			//BRAD KARATE CHOP!!
			StringBuilder sb = new StringBuilder (wholeFile);
			int chopCount = 0;
			int numChopped = 0;
			int i3 = 0;
			string arrayTmp = "abcdefghijklmnopqrstuvwxyz \".!?";
			for (int i2 = 0; i2 < wholeFile.Length; ++i2) {
				char tmp = wholeFile [i2];
				if (arrayTmp.IndexOf (tmp) < 0) {
					chopCount = (i2 - chopCount); //sets equal to index; starting at 0
					int chopPlace = Math.Abs (chopCount);
					sb.Remove (i3, 1);
					wholeFile = sb.ToString ();
					numChopped++;
				} else {
					i3++;
				}
				//may not be needed. same result without this
			}

			Console.WriteLine ("File Chopped!");
				
			for (int x2 = 0; x2 < wholeFile.Length; x2++) {
				string binary = Convert.ToString (wholeFile [x2], 2);
				//for (int x3 = 6; x3 != 3; x3--) {
					if (binary [0] == '0') {
						tempInt = 0;
					} else {
						tempInt = 1;
					}
					binQue.Enqueue (tempInt);
					queCount++;
				//}
			}
			int check48 = 0;
			int dequeCount = 0;
			for (int x4 = 0; x4 <= queCount- 1; x4++) {
				tempByte = Convert.ToByte (tempByte * 2);
				int tempExit = binQue.Dequeue ();
				if (tempExit == 1) {
					tempByte = Convert.ToByte (tempByte + 1);
					ByteQue.Enqueue (Convert.ToByte (tempByte));
					check48++;
					dequeCount++;
					if (check48 == 8) {
						tempByte = Convert.ToByte (0);
						check48 = 0;
					}
				}
			}
			Console.WriteLine ("File Compressed!");

			BinaryWriter bw;
			bw = new BinaryWriter (new FileStream ("Compressed.dat", FileMode.Create));

			for (int x5 = 0; x5 <= dequeCount - 1; x5++) {
				byte tempWriteMe = Convert.ToByte(ByteQue.Dequeue ());
				bw.Write (tempWriteMe);
			}
			Console.WriteLine ("PRAY TO GOD!");

		}

		/// <summary>///////////////////////////////////////////////////////////////////////////////////////////////////////////
		///
		/// </summary>
		/// <param name="args">The command-line arguments.</param> /////////////////////////////////////////////////////////////
		public static void Main (string [] args)
		{
			CompressorClass x = new CompressorClass ();
			x.codeTxt ();
			Console.ReadKey ();
		}
	}
}

