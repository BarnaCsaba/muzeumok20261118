using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace muzeumok
{
    public partial class Form1 : Form
    {
        private string[] muzeumNevek = new string[6];
        private List<Belepes> belepesek = new List<Belepes>();

        private int kastelyHelyijegyAr = 0;
        private int masHelyijegyAr = 0;
        private int napijegyAr = 0;
        private bool adatBetoltve = false;
        private string betoltottFajlEleresiUt = "";

        public Form1()
        {
            InitializeComponent();
            MuzeumNevekBetoltese();
            StatisztikaTablaElokeszitese();
        }

        private void MuzeumNevekBetoltese()
        {
            string fajlUtvonal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "muznev.txt");
            if (!File.Exists(fajlUtvonal))
            {
                MessageBox.Show(
                    "Nem található a muznev.txt fájl a program mappájában!",
                    "Hiányzó fájl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string[] sorok = File.ReadAllLines(fajlUtvonal, Encoding.UTF8);
            if (sorok.Length == 0)
            {
                MessageBox.Show("A muznev.txt fájl üres!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] darabok = sorok[0].Split(',');
            int db = 0;
            for (int i = 0; i < darabok.Length && db < 6; i++)
            {
                string tisztaNev = darabok[i].Trim().Trim('"');
                if (tisztaNev.Length > 0)
                {
                    muzeumNevek[db] = tisztaNev;
                    db++;
                }
            }
        }

        private void StatisztikaTablaElokeszitese()
        {
            dgvStatisztika.Columns.Clear();
            dgvStatisztika.Columns.Add("Ora", "óra");
            dgvStatisztika.Columns.Add("Fo", "fő");
            dgvStatisztika.Columns[0].Width = 65;
            dgvStatisztika.Columns[1].Width = 65;
        }

        private void btnFajlBetoltes_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Napi múzeumi adatfájl kiválasztása";
                ofd.Filter = "Szöveges fájl (*.txt)|*.txt|Minden fájl (*.*)|*.*";

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FajlFeldolgozasa(ofd.FileName);
            }
        }

        private void FajlFeldolgozasa(string fajlUtvonal)
        {
            string[] sorok = File.ReadAllLines(fajlUtvonal, Encoding.UTF8);
            if (sorok.Length < 1)
            {
                MessageBox.Show("A kiválasztott fájl üres!", "Hibás fájl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] arReszek = sorok[0].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (arReszek.Length < 3 ||
                !int.TryParse(arReszek[0], out kastelyHelyijegyAr) ||
                !int.TryParse(arReszek[1], out masHelyijegyAr) ||
                !int.TryParse(arReszek[2], out napijegyAr))
            {
                MessageBox.Show(
                    "Az első sor formátuma nem megfelelő! Várt érték: 3 egész szám szóközzel elválasztva.",
                    "Hibás adat az első sorban",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            List<Belepes> ujLista = new List<Belepes>();

            for (int i = 1; i < sorok.Length; i++)
            {
                string sor = sorok[i].Trim();
                if (sor.Length == 0)
                {
                    continue;
                }

                string[] reszek = sor.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (reszek.Length < 4)
                {
                    MessageBox.Show(
                        "Hibás adatsor a(z) " + (i + 1) + ". sorban! Várt formátum: óó:pp sorszám helyszín(0-5) jegytípus(T/K/TN/KN/-).",
                        "Hibás adatsor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                string ido = reszek[0];
                int jegyAz;
                int helyszinAz;
                string tipus = reszek[3];

                if (!IdoErvenyesE(ido) ||
                    !int.TryParse(reszek[1], out jegyAz) ||
                    !int.TryParse(reszek[2], out helyszinAz) ||
                    helyszinAz < 0 || helyszinAz > 5 ||
                    !JegytipusErvenyesE(tipus))
                {
                    MessageBox.Show(
                        "Érvénytelen adat a(z) " + (i + 1) + ". sorban! Ellenőrizd az időt (óó:pp), sorszámot, helyszínt (0-5) és jegytípust (T, K, TN, KN, -).",
                        "Érvénytelen adat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                ujLista.Add(new Belepes(ido, jegyAz, helyszinAz, tipus));
            }

            belepesek = ujLista;
            adatBetoltve = true;
            betoltottFajlEleresiUt = fajlUtvonal;

            lblFajlUtvonal.Text = "Fájl: " + Path.GetFileName(fajlUtvonal);
            lblBeolvasottAllapot.Text = "Állapot: beolvasva (" + belepesek.Count + " belépés, árak: " +
                kastelyHelyijegyAr + " / " + masHelyijegyAr + " / " + napijegyAr + ")";
            lblStatAllapot.Text = "Fájl: " + Path.GetFileNameWithoutExtension(fajlUtvonal) + "+stat.txt (még nem mentve)";

            OsszesElemzesFrissitese();
        }

        private bool IdoErvenyesE(string ido)
        {
            DateTime dt;
            return DateTime.TryParseExact(ido, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
        }

        private bool JegytipusErvenyesE(string tipus)
        {
            return tipus == "T" || tipus == "K" || tipus == "TN" || tipus == "KN" || tipus == "-";
        }

        private int IdoPercben(string ido)
        {
            string[] p = ido.Split(':');
            int ora = int.Parse(p[0]);
            int perc = int.Parse(p[1]);
            return ora * 60 + perc;
        }

        private string MuzeumNev(int helyszinAz)
        {
            if (helyszinAz >= 0 && helyszinAz < muzeumNevek.Length && !string.IsNullOrEmpty(muzeumNevek[helyszinAz]))
            {
                return muzeumNevek[helyszinAz];
            }
            return "Ismeretlen helyszín (" + helyszinAz + ")";
        }

        private void OsszesElemzesFrissitese()
        {
            if (!adatBetoltve)
            {
                return;
            }

            int osszesLatogatas = belepesek.Count;
            lblOsszesLatogatas.Text = "2. Összes látogatás: " + osszesLatogatas + " fő (belépés)";

            if (belepesek.Count == 0)
            {
                lblElsoBelepo.Text = "3. Első belépő: nincs adat";
                lblUtolsoBelepo.Text = "3. Utolsó belépő: nincs adat";
                lblZarasigIdo.Text = "5. Utolsó jegyvásárlás és 18:00 közötti idő: nincs adat";
                lblTeljesBevetel.Text = "6. Napi teljes bevétel: 0 Ft";
                lblNapijegyKastely.Text = "7. A napijegyet váltók általában nem a Kastélyban kezdtek.";
                return;
            }

            Belepes elso = belepesek[0];
            Belepes utolso = belepesek[0];
            int minPerc = IdoPercben(elso.Idobelyegzo);
            int maxPerc = IdoPercben(utolso.Idobelyegzo);

            for (int i = 1; i < belepesek.Count; i++)
            {
                int aktPerc = IdoPercben(belepesek[i].Idobelyegzo);
                if (aktPerc < minPerc)
                {
                    minPerc = aktPerc;
                    elso = belepesek[i];
                }
                if (aktPerc > maxPerc)
                {
                    maxPerc = aktPerc;
                    utolso = belepesek[i];
                }
            }

            lblElsoBelepo.Text = "3. Első belépő: " + elso.Idobelyegzo + " - " + MuzeumNev(elso.HelyszinAzonosito);
            lblUtolsoBelepo.Text = "3. Utolsó belépő: " + utolso.Idobelyegzo + " - " + MuzeumNev(utolso.HelyszinAzonosito);

            int zarasPerc = 18 * 60;
            int utolsoVasarloPerc = -1;

            for (int i = 0; i < belepesek.Count; i++)
            {
                if (belepesek[i].JegyTipus != "-")
                {
                    int p = IdoPercben(belepesek[i].Idobelyegzo);
                    if (p > utolsoVasarloPerc)
                    {
                        utolsoVasarloPerc = p;
                    }
                }
            }

            if (utolsoVasarloPerc == -1)
            {
                lblZarasigIdo.Text = "5. Utolsó jegyvásárlás és 18:00 közötti idő: nem volt jegyvásárlás";
            }
            else
            {
                int kulonbsegPerc = zarasPerc - utolsoVasarloPerc;
                if (kulonbsegPerc < 0)
                {
                    kulonbsegPerc = 0;
                }
                int ora = kulonbsegPerc / 60;
                int perc = kulonbsegPerc % 60;
                lblZarasigIdo.Text = "5. Utolsó jegyvásárlás és 18:00 közötti idő: " + ora + ":" + perc;
            }

            long teljesBevetel = 0;
            for (int i = 0; i < belepesek.Count; i++)
            {
                string tipus = belepesek[i].JegyTipus;
                int hely = belepesek[i].HelyszinAzonosito;

                if (tipus == "T")
                {
                    teljesBevetel += (hely == 0) ? kastelyHelyijegyAr : masHelyijegyAr;
                }
                else if (tipus == "K")
                {
                    teljesBevetel += (hely == 0) ? (kastelyHelyijegyAr / 2) : (masHelyijegyAr / 2);
                }
                else if (tipus == "TN")
                {
                    teljesBevetel += napijegyAr;
                }
                else if (tipus == "KN")
                {
                    teljesBevetel += napijegyAr / 2;
                }
            }

            lblTeljesBevetel.Text = "6. Napi teljes bevétel: " + teljesBevetel + " Ft";

            int napijegyValtoOsszes = 0;
            int napijegyValtoKastelyban = 0;

            for (int i = 0; i < belepesek.Count; i++)
            {
                string tipus = belepesek[i].JegyTipus;
                if (tipus == "TN" || tipus == "KN")
                {
                    napijegyValtoOsszes++;
                    if (belepesek[i].HelyszinAzonosito == 0)
                    {
                        napijegyValtoKastelyban++;
                    }
                }
            }

            if (napijegyValtoOsszes > 0 && napijegyValtoKastelyban * 2 > napijegyValtoOsszes)
            {
                lblNapijegyKastely.Text = "7. A napijegyet váltók általában a Kastélyban kezdtek.";
            }
            else
            {
                lblNapijegyKastely.Text = "7. A napijegyet váltók általában nem a Kastélyban kezdtek.";
            }
        }

       
        private void btnJegyKereses_Click(object sender, EventArgs e)
        {
            if (!adatBetoltve)
            {
                MessageBox.Show(
                    "Előbb tölts be egy napi .txt fájlt (1. feladat)!",
                    "Nincs betöltött fájl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            string bevitel = txtJegyAzonosito.Text.Trim();
            int keresettAzonosito;
            if (!int.TryParse(bevitel, out keresettAzonosito))
            {
                MessageBox.Show(
                    "Érvénytelen sorszám! Kérjük, egész számot adj meg (várt érték: egész szám, pl. 12).",
                    "Hibás bemenet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtJegyAzonosito.Focus();
                return;
            }

            List<string> talalatok = new List<string>();
            for (int i = 0; i < belepesek.Count; i++)
            {
                if (belepesek[i].JegyAzonosito == keresettAzonosito)
                {
                    talalatok.Add(belepesek[i].Idobelyegzo + " - " + MuzeumNev(belepesek[i].HelyszinAzonosito));
                }
            }

            if (talalatok.Count == 0)
            {
                lblJegyEredmeny.Text = "Eredmény: -";
            }
            else
            {
                lblJegyEredmeny.Text = "Eredmény: " + string.Join("; ", talalatok.ToArray());
            }
        }

        
        private void btnStatMentese_Click(object sender, EventArgs e)
        {
            if (!adatBetoltve)
            {
                MessageBox.Show(
                    "Előbb tölts be egy napi .txt fájlt (1. feladat)!",
                    "Nincs betöltött fájl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            int[] oraDarab = new int[9];

            for (int i = 0; i < belepesek.Count; i++)
            {
                if (belepesek[i].HelyszinAzonosito == 0)
                {
                    string[] idoResz = belepesek[i].Idobelyegzo.Split(':');
                    int ora = int.Parse(idoResz[0]);
                    if (ora >= 10 && ora <= 18)
                    {
                        oraDarab[ora - 10]++;
                    }
                }
            }

            dgvStatisztika.Rows.Clear();
            List<string> kimenetiSorok = new List<string>();
            kimenetiSorok.Add("óra\tfő");

            for (int idx = 0; idx < 9; idx++)
            {
                int ora = 10 + idx;
                int fo = oraDarab[idx];
                dgvStatisztika.Rows.Add(ora, fo);
                kimenetiSorok.Add(ora + "\t" + fo);
            }

            string konyvtar = Path.GetDirectoryName(betoltottFajlEleresiUt);
            string alapNev = Path.GetFileNameWithoutExtension(betoltottFajlEleresiUt);
            string kimenetiFajl = Path.Combine(konyvtar, alapNev + "+stat.txt");

            File.WriteAllLines(kimenetiFajl, kimenetiSorok.ToArray(), Encoding.UTF8);

            lblStatAllapot.Text = "Mentve: " + Path.GetFileName(kimenetiFajl);
            MessageBox.Show(
                "A statisztika sikeresen elmentve:\n" + kimenetiFajl,
                "Mentés kész",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}