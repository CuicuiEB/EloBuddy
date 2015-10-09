using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Color = System.Drawing.Color;

namespace Cui_Tristana
{
    class Program
    {
        public static Menu Menu,
            DrawMenu,
            ComboMenu;

        public static Spell.Active Q;
        public static Spell.Skillshot W;
        public static Spell.Targeted E;
        public static Spell.Targeted R;

        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }

        static void Main(string[] args) //cargamos todo
        {
            Loading.OnLoadingComplete += Game_OnStart;
            Drawing.OnDraw += Game_OnDraw;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnStart(EventArgs args) // Cuando el juego empiece :v
        {
            Chat.Print("Im new in this - Cuicui");

            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Skillshot(SpellSlot.W, 900, SkillShotType.Circular);
            E = new Spell.Targeted(SpellSlot.E, 575);
            R = new Spell.Targeted(SpellSlot.R, 575);

            Menu = MainMenu.AddMenu("CUI Tristana", "cuiTristana"); 
            Menu.AddSeparator();
            Menu.AddLabel("Creado por Cuicui");

// Agregamos los Drawings
            DrawMenu = Menu.AddSubMenu("Draw", "CUI Drawings");
            DrawMenu.Add("drawDisable", new CheckBox("Saca todos los drawings", true));
            ComboMenu = Menu.AddSubMenu("Combo", "cuiComboTristana");
            ComboMenu.Add("comboQ", new CheckBox("Usar la Q [en combo]", true));
            ComboMenu.Add("comboW", new CheckBox("Usar la W [en combo]", true));
            ComboMenu.Add("comboE", new CheckBox("Usar la E [en combo]", true));
            ComboMenu.Add("comboR", new CheckBox("Usart la R [en combo]", true));

        }
