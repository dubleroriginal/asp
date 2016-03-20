using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSmartHouse
{
    public class FormForDevice : Panel
    {

        #region Переменные

        // состояние устройства Вкл/Выкл
        private Button stateButton;
        private Label state;

        //яркость
        private Label brightnessVolue;
        private Button brightnessUp;
        private Button brightnessDown;
        // Цвет
        private DropDownList colorVolue;
        private Label colorLight;
        //Канал
        private Label currentChanel;
        private DropDownList chооseChanel;
        private Button chanelUp;
        private Button chanelDown;
        //Заморозка
        private Label programFridge;
        private Button programFridgeUp;
        private Button programFridgeDown;
        private Button frizeButton;
        private Label frizeState;
        //Кондиционер
        private Label programCond;
        private Button programCondUp;
        private Button programCondDown;

        private Button deleteButton;
        //Режим
        private Button modeTR;
        private Label modeState;
        //Громкость
        private Label volume;
        private Button volumeUp;
        private Button volumeDown;



        private int id;  // номер устройства
        private IDictionary<int, Device> allDeviceList;  //список устройств

        #endregion

        public FormForDevice(int id, IDictionary<int, Device> allDeviceList)
        {
            this.allDeviceList = allDeviceList;
            this.id = id;
            Initializer();
        }


        //Инициализатор графики
        protected void Initializer()
        {
            CssClass = "Devicediv";
            Controls.Add(Span("Name: " + allDeviceList[id].Name + "<br />"));

            stateButton = new Button();
            stateButton.Text = "Вкл/Выкл";
            stateButton.Click += StateButtonClick;
            Controls.Add(stateButton);


            switch (allDeviceList[id].Id)
            {
                case "Lamp":

                    InitializLamp();
                    break;

                case "Fridge":

                    InitializFridge();
                    break;

                case "TR":

                    InitializTR();
                    break;

                case "Cond":

                    InitializCond();
                    break;

                case "TV":

                    InitializTV();
                    break;

                case "Kettle":

                    InitializKettle();
                    break;
            }



            Controls.Add(Span("<br />"));

            deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Click += DeleteButtonClick;
            Controls.Add(deleteButton);

        }




        //Создание элементов    
        private DropDownList DropDownList(string selectId, List<string> value)
        {
            DropDownList lb = new System.Web.UI.WebControls.DropDownList();
            lb.AutoPostBack = true;
            lb.Width = 70;
            lb.Height = 20;
            for (int i = 0; i < value.Count; i++)
            {
                lb.Items.Add(value[i]);
            }

            lb.ID = selectId + id.ToString();
            lb.SelectedIndexChanged += ListBoxChanged;
            lb.Enabled = false;

            return lb;
        }
        private Label Label(string Text, string SelectID)
        {
            Label lab = new Label();
            lab.Text = Text;
            lab.ID = SelectID + id.ToString();
            return lab;
        }
        private Button Button(string selectid, string TextButt, int width, int height)
        {
            Button but = new Button();
            but.Enabled = false;
            but.Text = TextButt;
            but.ID = selectid + id.ToString();
            but.Width = width;
            but.Height = height;
            but.Click += ButtonClick;

            return but;
        }
        private TextBox TextBox(string SelectID)
        {
            TextBox Tb = new System.Web.UI.WebControls.TextBox();
            Tb.ID = SelectID + id.ToString();
            Tb.Width = 80;
            Tb.Height = 10;

            return Tb;
        }
        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

        //Обработка событий
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            allDeviceList.Remove(id); // Удаление фигуры из коллекцию
            Parent.Controls.Remove(this); // Удаление графики для фигуры
        }
        private void StateButtonClick(object sender, EventArgs e)
        {
            switch (allDeviceList[id].Id)
            {
                case "Lamp":
                    ((Lamp)allDeviceList[id]).Switch();
                    string st = ((Lamp)allDeviceList[id]).ToString();
                    state.Text = st;

                    brightnessUp.Enabled = ((Lamp)allDeviceList[id]).State;
                    brightnessDown.Enabled = ((Lamp)allDeviceList[id]).State;
                    colorVolue.Enabled = ((Lamp)allDeviceList[id]).State;

                    break;

                case "Fridge":
                    ((Fridge)allDeviceList[id]).Switch();
                    string ft = ((Fridge)allDeviceList[id]).ToString();
                    state.Text = ft;

                    frizeButton.Enabled = ((Fridge)allDeviceList[id]).State;
                    programFridgeDown.Enabled = ((Fridge)allDeviceList[id]).State;
                    programFridgeUp.Enabled = ((Fridge)allDeviceList[id]).State;
                    break;

                case "Cond":
                    ((AirConditioning)allDeviceList[id]).Switch();
                    string ct = ((AirConditioning)allDeviceList[id]).ToString();
                    state.Text = ct;

                    programCondDown.Enabled = ((AirConditioning)allDeviceList[id]).State;
                    programCondUp.Enabled = ((AirConditioning)allDeviceList[id]).State;


                    break;

                case "TR":
                    ((StereoSystem)allDeviceList[id]).Switch();
                    string tt = ((StereoSystem)allDeviceList[id]).ToString();
                    state.Text = tt;

                    modeTR.Enabled = ((StereoSystem)allDeviceList[id]).State;
                    volumeDown.Enabled = ((StereoSystem)allDeviceList[id]).State;
                    volumeUp.Enabled = ((StereoSystem)allDeviceList[id]).State;
                    break;

                case "Kettle":
                    ((Kettle)allDeviceList[id]).Switch();
                    string kt = ((Kettle)allDeviceList[id]).ToString();
                    state.Text = kt;
                    break;

                case "TV":
                    ((TeleVision)allDeviceList[id]).Switch();
                    string vt = ((TeleVision)allDeviceList[id]).ToString();
                    state.Text = vt;

                    chanelUp.Enabled = ((TeleVision)allDeviceList[id]).State;
                    chanelDown.Enabled = ((TeleVision)allDeviceList[id]).State;
                    chооseChanel.Enabled = ((TeleVision)allDeviceList[id]).State;
                    brightnessUp.Enabled = ((TeleVision)allDeviceList[id]).State;
                    brightnessDown.Enabled = ((TeleVision)allDeviceList[id]).State;
                    break;
            }

        }
        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {

                case "->":

                    if (allDeviceList[id].State)
                    {
                        switch (allDeviceList[id].Id)
                        {
                            case "Lamp":

                                ((Lamp)allDeviceList[id]).BrightnesUp();
                                brightnessVolue.Text = ((Lamp)allDeviceList[id]).BrightnessRetutn();
                                break;

                            case "Fridge":

                                ((Fridge)allDeviceList[id]).ProgrammUP();
                                programFridge.Text = Convert.ToString(((Fridge)allDeviceList[id]).GetPower());
                                break;

                            case "TR":

                                ((StereoSystem)allDeviceList[id]).VolumeUp();
                                volume.Text = Convert.ToString(((StereoSystem)allDeviceList[id]).GetVolume());
                                break;

                            case "Cond":

                                ((AirConditioning)allDeviceList[id]).ProgramUp();
                                programCond.Text = ((AirConditioning)allDeviceList[id]).ProgramState();
                                break;

                            case "TV":

                                ((TeleVision)allDeviceList[id]).BrightnesUp();
                                brightnessVolue.Text = ((TeleVision)allDeviceList[id]).ReturnBrightness();
                                break;

                        }

                    }
                    break;

                case "<-":

                    if (allDeviceList[id].State)
                    {
                        switch (allDeviceList[id].Id)
                        {
                            case "Lamp":

                                ((Lamp)allDeviceList[id]).BrightnesDown();
                                brightnessVolue.Text = ((Lamp)allDeviceList[id]).BrightnessRetutn();
                                break;

                            case "Fridge":

                                ((Fridge)allDeviceList[id]).ProgrammDown();
                                programFridge.Text = Convert.ToString(((Fridge)allDeviceList[id]).GetPower());
                                break;

                            case "TR":

                                ((StereoSystem)allDeviceList[id]).VolumeDown();
                                volume.Text = Convert.ToString(((StereoSystem)allDeviceList[id]).GetVolume());
                                break;

                            case "Cond":

                                ((AirConditioning)allDeviceList[id]).ProgramDown();
                                programCond.Text = ((AirConditioning)allDeviceList[id]).ProgramState();
                                break;

                            case "TV":

                                ((TeleVision)allDeviceList[id]).BrightnesDown();
                                brightnessVolue.Text = ((TeleVision)allDeviceList[id]).ReturnBrightness();
                                break;
                        }
                    }

                    break;

                case "Frize On/Off":

                    ((Fridge)allDeviceList[id]).SwitchFrize();
                    frizeState.Text = ((Fridge)allDeviceList[id]).ToStringFrize();
                    break;

                case "Radio/CD":

                    ((StereoSystem)allDeviceList[id]).Mode();
                    modeState.Text = ((StereoSystem)allDeviceList[id]).StateMode();

                    break;

                case "-->":

                    if (allDeviceList[id].Id == "TV" && allDeviceList[id].State)
                    {
                        ((TeleVision)allDeviceList[id]).ChangeUp();
                        currentChanel.Text = ((TeleVision)allDeviceList[id]).GetChanel();
                    }

                    break;

                case "<--":

                    if (allDeviceList[id].Id == "TV" && allDeviceList[id].State)
                    {
                        ((TeleVision)allDeviceList[id]).ChangeDown();
                        currentChanel.Text = ((TeleVision)allDeviceList[id]).GetChanel();
                    }

                    break;
            }
        }
        private void ListBoxChanged(object sender, EventArgs e)
        {

            if (allDeviceList[id].Id == "Lamp" && allDeviceList[id].State)
            {
                ((Lamp)allDeviceList[id]).SelectColor(Convert.ToString(colorVolue.SelectedItem));
                colorLight.BackColor = ((Lamp)allDeviceList[id]).ReturnColor();
            }

            else if (allDeviceList[id].Id == "TV" && allDeviceList[id].State)
            {
                ((TeleVision)allDeviceList[id]).ChuseChanal(chооseChanel.SelectedIndex);
                currentChanel.Text = ((TeleVision)allDeviceList[id]).GetChanel();
            }
        }



        //Создание графики для каждого устройства
        private void InitializLamp()
        {
            Controls.Add(Span("      "));
            state = Label(((Lamp)allDeviceList[id]).ToString(), "St");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));

            Controls.Add(Span("Brightnes: "));
            Controls.Add(Span("           "));


            brightnessVolue = Label(((Lamp)allDeviceList[id]).BrightnessRetutn(), "Br");
            Controls.Add(brightnessVolue);
            brightnessUp = Button("UpBut", "<-", 30, 20);
            Controls.Add(brightnessUp);


            brightnessDown = Button("DowBut", "->", 30, 20);
            Controls.Add(brightnessDown);

            List<string> color = new List<string>();
            string h;
            Controls.Add(Span("<br/> "));
            colorLight = Label("Color light: ", "CI");
            Controls.Add(colorLight);

            h = "White"; color.Add(h);
            h = "Green"; color.Add(h);
            h = "Blue"; color.Add(h);
            h = "Red"; color.Add(h);
            h = "Yellow"; color.Add(h);

            colorVolue = DropDownList("Cl", color);
            Controls.Add(colorVolue);


            colorLight.BackColor = ((Lamp)allDeviceList[id]).ReturnColor();
            brightnessUp.Enabled = ((Lamp)allDeviceList[id]).State;
            brightnessDown.Enabled = ((Lamp)allDeviceList[id]).State;
            colorVolue.Enabled = ((Lamp)allDeviceList[id]).State;

        }
        private void InitializFridge()
        {
            Controls.Add(Span("      "));
            state = Label(((Fridge)allDeviceList[id]).ToString(), "St");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));

            frizeButton = Button("FrizBut", "Frize On/Off", 90, 20);
            frizeState = Label(((Fridge)allDeviceList[id]).ToStringFrize(), "Fr");
            Controls.Add(frizeButton);
            Controls.Add(frizeState);
            Controls.Add(Span("<br/> "));



            Controls.Add(Span("Programm: "));
            Controls.Add(Span("           "));


            programFridge = Label(Convert.ToString(((Fridge)allDeviceList[id]).GetPower()), "PrFr");
            Controls.Add(programFridge);
            programFridgeUp = Button("UpButFr", "<-", 30, 20);
            Controls.Add(programFridgeUp);


            programFridgeDown = Button("DowButFr", "->", 30, 20);
            Controls.Add(programFridgeDown);


            frizeButton.Enabled = ((Fridge)allDeviceList[id]).State;
            programFridgeDown.Enabled = ((Fridge)allDeviceList[id]).State;
            programFridgeUp.Enabled = ((Fridge)allDeviceList[id]).State;

        }
        private void InitializTR()
        {
            Controls.Add(Span("      "));
            state = Label(((StereoSystem)allDeviceList[id]).ToString(), "StTR");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));

            modeTR = Button("ModTR", "Radio/CD", 70, 20);
            modeState = Label(((StereoSystem)allDeviceList[id]).StateMode(), "ModeTr");
            Controls.Add(modeTR);
            Controls.Add(modeState);
            Controls.Add(Span("<br/> "));


            Controls.Add(Span("Volume: "));
            Controls.Add(Span("           "));


            volume = Label(Convert.ToString(((StereoSystem)allDeviceList[id]).GetVolume()), "volTr");
            Controls.Add(volume);
            volumeUp = Button("VolUpBut", "<-", 30, 20);
            Controls.Add(volumeUp);


            volumeDown = Button("VolDowBut", "->", 30, 20);
            Controls.Add(volumeDown);


            modeTR.Enabled = ((StereoSystem)allDeviceList[id]).State;
            volumeDown.Enabled = ((StereoSystem)allDeviceList[id]).State;
            volumeUp.Enabled = ((StereoSystem)allDeviceList[id]).State;

        }
        private void InitializCond()
        {
            Controls.Add(Span("      "));
            state = Label(((AirConditioning)allDeviceList[id]).ToString(), "StCon");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));


            Controls.Add(Span("Program: "));
            Controls.Add(Span("      "));
            programCond = Label(((AirConditioning)allDeviceList[id]).ProgramState(), "ConPr");
            programCondUp = Button("PrUp", "<-", 30, 20);

            Controls.Add(programCond);
            Controls.Add(programCondUp);

            programCondDown = Button("PrDown", "->", 30, 20);
            Controls.Add(programCondDown);
            Controls.Add(Span("<br/> "));

            programCondDown.Enabled = ((AirConditioning)allDeviceList[id]).State;
            programCondUp.Enabled = ((AirConditioning)allDeviceList[id]).State;
        }
        private void InitializTV()
        {
            Controls.Add(Span("      "));
            state = Label(((TeleVision)allDeviceList[id]).ToString(), "StTV");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));



            Controls.Add(Span("Chanel: "));
            Controls.Add(Span("           "));


            currentChanel = Label(Convert.ToString(((TeleVision)allDeviceList[id]).GetChanel()), "ChTV");
            Controls.Add(currentChanel);

            chanelDown = Button("DownChBut", "<--", 30, 20);
            Controls.Add(chanelDown);
            chanelUp = Button("UpChBut", "-->", 30, 20);
            Controls.Add(chanelUp);
            Controls.Add(Span("Chanel: "));

            List<string> chanel = new List<string>();

            chanel.Add("1+1");
            chanel.Add("Интер");
            chanel.Add("ТРК Украина");
            chanel.Add("ТЕТ");
            chanel.Add("Dicovery");
            chanel.Add("Lion");
            chanel.Add("ICTV");

            chооseChanel = DropDownList("Chl", chanel);
            Controls.Add(chооseChanel);

            Controls.Add(Span("<br/> "));

            Controls.Add(Span("Brightnes: "));
            Controls.Add(Span("           "));

            brightnessVolue = Label(((TeleVision)allDeviceList[id]).ReturnBrightness(), "Br");
            Controls.Add(brightnessVolue);

            brightnessUp = Button("UpBut", "<-", 30, 20);
            Controls.Add(brightnessUp);
            brightnessDown = Button("DowBut", "->", 30, 20);
            Controls.Add(brightnessDown);


            chanelUp.Enabled = ((TeleVision)allDeviceList[id]).State;
            chanelDown.Enabled = ((TeleVision)allDeviceList[id]).State;
            chооseChanel.Enabled = ((TeleVision)allDeviceList[id]).State;
            brightnessUp.Enabled = ((TeleVision)allDeviceList[id]).State;
            brightnessDown.Enabled = ((TeleVision)allDeviceList[id]).State;
        }
        private void InitializKettle()
        {
            Controls.Add(Span("      "));
            state = Label(((Kettle)allDeviceList[id]).ToString(), "StKet");
            Controls.Add(state);
            Controls.Add(Span("<br/> "));


        }


    }
}