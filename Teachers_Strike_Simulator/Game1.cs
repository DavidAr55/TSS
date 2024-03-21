using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Teachers_Strike_Simulator
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        AudioEngine engine;
        SoundBank soundBank;
        WaveBank waveBank;
        Cue cancion;

        SpriteFont FuenteJugador1, FuenteJugador2;
        //PERSONAJES -------------------------------------------------------------------------------------------//
        Vector2 PQuiroz;
        Texture2D TQuiroz;
        Texture2D Quiroz_Der, Quiroz_Run_Der1, Quiroz_Run_Der2, Quiroz_Run_Der3, Quiroz_Jump_Der, Quiroz_Attac1_Der, Quiroz_Attac2_Der, Quiroz_Attac3_Der, QzUSB1;
        Texture2D Quiroz_Izq, Quiroz_Run_Izq1, Quiroz_Run_Izq2, Quiroz_Run_Izq3, Quiroz_Jump_Izq, Quiroz_Attac1_Izq, Quiroz_Attac2_Izq, Quiroz_Attac3_Izq, QzUSB2;
        BoundingBox BQuiroz;
        int banderaQz = 0, TiempoUlti = 0;
        bool DireccionQZ = true;
        bool caeQZ = false;
        float masaQZ;
        float tiemposueltoQZ;
        float timeUPQZ;
        bool Heal = false;
        //Atributos de Quiroz------------------------------//
        //Disparos---------------------------------//
        //estructura para el disparo pra el lado DERECHO---------------------------------
        public struct DatosDisparoDerQZ
        {
            public Vector2 posDisparoDerQZ;
            public float velDiaparoDerQZ;
            public Texture2D disparoDerQZ;
        }

        //creamos la lista para los disparos
        List<DatosDisparoDerQZ> ListaDisparosDerQZ;
        DatosDisparoDerQZ disparoDerQZ;
        KeyboardState kbDerQZ;


        //estructura para el disparo pra el lado IZQUIERDO---------------------------------
        public struct DatosDisparoIzqQZ
        {
            public Vector2 posDisparoIzqQZ;
            public float velDiaparoIzqQZ;
            public Texture2D disparoIzqQZ;
        }

        //creamos la lista para los disparos
        List<DatosDisparoIzqQZ> ListaDisparosIzqQZ;
        DatosDisparoIzqQZ disparoIzqQZ;
        KeyboardState kbIzqQZ;
        //---------------------------------Disparos//

        //Ulti de Quiroz--------------------------------//
        public struct DatosDisparoUltiDer
        {
            public Vector2 posRayoUltiDer;
            public float velRayoUltiDer;
            public Texture2D rayoUltiDer;
            public float rotacionUltiDer;
        }
        public struct DatosDisparoUltiIzq
        {
            public Vector2 posRayoUltiIzq;
            public float velRayoUltiIzq;
            public Texture2D rayoUltiIzq;
            public float rotacionUltiIzq;
        }
        List<DatosDisparoUltiDer> ListaDisparosUltiDer;
        List<DatosDisparoUltiIzq> ListaDisparosUltiIzq;

        DatosDisparoUltiDer disparoUltiDer;
        DatosDisparoUltiIzq disparoUltiIzq;
        //--------------------------------Ulti de Quiroz//
        //------------------------------Atributos de Quiroz//






        //Atributos de Anaya------------------------------//
        Vector2 PAnaya;
        Texture2D TAnaya;
        Texture2D Anaya_Der, Anaya_Run_Der1, Anaya_Run_Der2, Anaya_Run_Der3, Anaya_Run_Der4, Anaya_Jump_Der, Anaya_Attac1_Der, Anaya_Attac2_Der, Anaya_Attac3_Der, Anaya_Ulti_Der, AnayaPI;
        Texture2D Anaya_Izq, Anaya_Run_Izq1, Anaya_Run_Izq2, Anaya_Run_Izq3, Anaya_Run_Izq4, Anaya_Jump_Izq, Anaya_Attac1_Izq, Anaya_Attac2_Izq, Anaya_Attac3_Izq, Anaya_Ulti_Izq;
        Texture2D Rayos1;
        Vector2 pos_Rayos;
        BoundingBox BAnaya;
        int banderaAn = 0;
        bool DireccionAn = true;
        bool caeAn = false;
        float masaAn;
        float tiemposueltoAn;
        float timeUPAn;
        int TiempoDash = 0, DashAnaya = 0;
        bool ActivarDash = false;
        bool TodoPoderos = false;
        int TiempoTodoPoderos = 0;
        int pos_randomRayo;
        Random rnd_rayo;
        //Disparos---------------------------------//
        //estructura para el disparo pra el lado DERECHO---------------------------------
        public struct DatosDisparoDerAn
        {
            public Vector2 posDisparoDerAn;
            public float velDiaparoDerAn;
            public Texture2D disparoDerAn;
        }

        //creamos la lista para los disparos
        List<DatosDisparoDerAn> ListaDisparosDerAn;
        DatosDisparoDerAn disparoDerAn;
        KeyboardState kbDerAn;

        //estructura para el disparo pra el lado IZQUIERDO---------------------------------
        public struct DatosDisparoIzqAn
        {
            public Vector2 posDisparoIzqAn;
            public float velDiaparoIzqAn;
            public Texture2D disparoIzqAn;
        }

        //creamos la lista para los disparos
        List<DatosDisparoIzqAn> ListaDisparosIzqAn;
        DatosDisparoIzqAn disparoIzqAn;
        KeyboardState kbIzqAn;
        //---------------------------------Disparos//
        //------------------------------Atributos de Anaya//



        Vector2 PZama;
        Texture2D TZama;
        Texture2D Zamarripa_Der, Zamarripa_Run_Der1, Zamarripa_Run_Der2, Zamarripa_Run_Der3, Zamarripa_Run_Der4, Zamarripa_Jump_Der, Zamarripa_Attac1_Der, Zamarripa_Attac2_Der, Baston_Der;
        Texture2D Zamarripa_Izq, Zamarripa_Run_Izq1, Zamarripa_Run_Izq2, Zamarripa_Run_Izq3, Zamarripa_Run_Izq4, Zamarripa_Jump_Izq, Zamarripa_Attac1_Izq, Zamarripa_Attac2_Izq, Baston_Izq;

        Texture2D UltiZamarripa_Der, UltiZamarripa_Run_Der1, UltiZamarripa_Run_Der2, UltiZamarripa_Run_Der3, UltiZamarripa_Run_Der4, UltiZamarripa_Jump_Der, UltiZamarripa_Attac1_Der, UltiZamarripa_Attac2_Der, UltiBaston_Der;
        Texture2D UltiZamarripa_Izq, UltiZamarripa_Run_Izq1, UltiZamarripa_Run_Izq2, UltiZamarripa_Run_Izq3, UltiZamarripa_Run_Izq4, UltiZamarripa_Jump_Izq, UltiZamarripa_Attac1_Izq, UltiZamarripa_Attac2_Izq, UltiBaston_Izq;
        BoundingBox BZama;
        int banderaZa = 0;
        bool caeZA = false;
        float masaZA;
        float tiemposueltoZA;
        float timeUPZA;
        bool DireccionZa = true;
        bool GanchoFin = false;
        bool StormBreaker = false;
        int TiempoStormBreaker = 0;
        //Atributos de Zamarripa------------------------------//
        //Disparos---------------------------------//
        public struct DatosDisparo1
        {
            public Vector2 posRayo1;
            public float velRayo1;
            public Texture2D rayo1;
            public Texture2D Ultirayo1;
            public float rotacion1;
        }
        public struct DatosDisparo2
        {
            public Vector2 posRayo2;
            public float velRayo2;
            public Texture2D rayo2;
            public Texture2D Ultirayo2;
            public float rotacion2;
        }
        List<DatosDisparo1> ListaDisparos1;
        List<DatosDisparo2> ListaDisparos2;

        DatosDisparo1 disparo1;
        DatosDisparo2 disparo2;
        KeyboardState kb1, kb2;

        bool LansarGancho = false;
        Vector2 pos_Gancho;
        Texture2D GanchoDer, GanchoIzq;
        Texture2D UltiGanchoDer, UltiGanchoIzq;
        BoundingBox BGancho;
        //---------------------------------Disparos//






        //Atributos de Guillen------------------------------//
        Vector2 PGuillen;
        Texture2D TGuillen;
        Texture2D Guillen_Der, Guillen_Run_Der1, Guillen_Run_Der2, Guillen_Run_Der3, Guillen_Run_Der4, Guillen_Jump_Der, Guillen_Attac1_Der, Guillen_Attac2_Der;
        Texture2D Guillen_Izq, Guillen_Run_Izq1, Guillen_Run_Izq2, Guillen_Run_Izq3, Guillen_Run_Izq4, Guillen_Jump_Izq, Guillen_Attac1_Izq, Guillen_Attac2_Izq;
        BoundingBox BGuillen;
        int banderaGn = 0;
        bool caeGn = false;
        float masaGn;
        float tiemposueltoGn;
        float timeUPGn;
        bool DireccionGn = true;
        bool Invisivilidad = false;
        int TiempoInvicible = 0;
        Texture2D Reloj;
        Vector2 pos_reloj;
        BoundingBox BReloj;
        bool LanzarReloj = false, Inmovil = false, NoCaminarGn = false;
        int TiempoParaReaccion = 0, TiempoInmovil = 0;
        //Atributos de Guillen------------------------------//
        //Disparos---------------------------------//
        public struct DatosDisparo_IzqGn
        {
            public Vector2 posRayo_IzqGn;
            public float velRayo_IzqGn;
            public Texture2D rayo_IzqGn;
            public float rotacion_IzqGn;
        }
        public struct DatosDisparo_DerGn
        {
            public Vector2 posRayo_DerGn;
            public float velRayo_DerGn;
            public Texture2D rayo_DerGn;
            public float rotacion_DerGn;
        }
        List<DatosDisparo_IzqGn> ListaDisparos_IzqGn;
        List<DatosDisparo_DerGn> ListaDisparos_DerGn;

        DatosDisparo_IzqGn disparo_IzqGn;
        DatosDisparo_DerGn disparo_DerGn;
        KeyboardState kb1Gn, kb2Gn;
        //------------------------------Atributos de Guillen//







        //Atributos de Cañez------------------------------//
        Vector2 PCanez;
        Texture2D TCanez;
        Texture2D Canez_Der, Canez_Run_Der1, Canez_Run_Der2, Canez_Run_Der3, Canez_Run_Der4, Canez_Run_Der5, Canez_Jump_Der, Canez_Attac1_Der, Canez_Attac2_Der, Canez_Attac3_Der, Canez_Ulti_Der, Gema;
        Texture2D Canez_Izq, Canez_Run_Izq1, Canez_Run_Izq2, Canez_Run_Izq3, Canez_Run_Izq4, Canez_Run_Izq5, Canez_Jump_Izq, Canez_Attac1_Izq, Canez_Attac2_Izq, Canez_Attac3_Izq, Canez_Ulti_Izq;
        BoundingBox BCanez;
        int banderaCz = 0;
        bool DireccionCz = true;
        bool caeCz = false;
        float masaCz;
        float tiemposueltoCz;
        float timeUPCz;
        bool HealCz = false, ChasquidoCz = false;
        //Disparos---------------------------------//
        //estructura para el disparo pra el lado DERECHO---------------------------------
        public struct DatosDisparoDerCz
        {
            public Vector2 posDisparoDerCz;
            public float velDiaparoDerCz;
            public Texture2D disparoDerCz;
        }

        //creamos la lista para los disparos
        List<DatosDisparoDerCz> ListaDisparosDerCz;
        DatosDisparoDerCz disparoDerCz;
        KeyboardState kbDerCz;

        //estructura para el disparo pra el lado IZQUIERDO---------------------------------
        public struct DatosDisparoIzqCz
        {
            public Vector2 posDisparoIzqCz;
            public float velDiaparoIzqCz;
            public Texture2D disparoIzqCz;
        }

        //creamos la lista para los disparos
        List<DatosDisparoIzqCz> ListaDisparosIzqCz;
        DatosDisparoIzqCz disparoIzqCz;
        KeyboardState kbIzqCz;
        //---------------------------------Disparos//
        //------------------------------Atributos de Cañez//








        //Atributos de Castruita------------------------------//
        Vector2 PCastru;
        Texture2D TCastru;
        Texture2D Castru_Der, Castru_Run_Der1, Castru_Run_Der2, Castru_Run_Der3, Castru_Run_Der4, Castru_Jump_Der, Castru_Attac1_Der, Castru_Attac2_Der, Castru_Attac3_Der;
        Texture2D Castru_Izq, Castru_Run_Izq1, Castru_Run_Izq2, Castru_Run_Izq3, Castru_Run_Izq4, Castru_Jump_Izq, Castru_Attac1_Izq, Castru_Attac2_Izq, Castru_Attac3_Izq;
        BoundingBox BCastru;
        int banderaCa = 0;
        bool caeCa = false;
        float masaCa;
        float tiemposueltoCa;
        float timeUPCa;
        bool DireccionCa = true;
        int CastruHab2 = 0, TiempoCafeina = 0;
        bool ActivarCafeina = false;
        Texture2D GranoCafe, explocion;
        Vector2 pos_GranoCafe;
        BoundingBox BGranoCafe;
        bool LanzarGrano = false, NoCaminarCa = false, Explotar = false, MostrarExplocion = false;

        //Atributos de Castruita------------------------------//
        //Disparos---------------------------------//
        public struct DatosDisparo_IzqCa
        {
            public Vector2 posRayo_IzqCa;
            public float velRayo_IzqCa;
            public Texture2D rayo_IzqCa;
            public float rotacion_IzqCa;
        }
        public struct DatosDisparo_DerCa
        {
            public Vector2 posRayo_DerCa;
            public float velRayo_DerCa;
            public Texture2D rayo_DerCa;
            public float rotacion_DerCa;
        }
        List<DatosDisparo_IzqCa> ListaDisparos_IzqCa;
        List<DatosDisparo_DerCa> ListaDisparos_DerCa;

        DatosDisparo_IzqCa disparo_IzqCa;
        DatosDisparo_DerCa disparo_DerCa;
        KeyboardState kb1Ca, kb2Ca;
        //------------------------------Atributos de Castruita//











        //Escenarios--------------------------------------------------------------------------------------------//
        Escenario1 escenario1;
        Escenario2 escenario2;
        Escenario3 escenario3;
        Escenario4 escenario4;
        Escenario5 escenario5;

        int SpownQz = 0, SpownAn = 0, SpownZa = 0, SpownGn = 0, SpownCz = 0, SpownCa = 0;
        int QzTiempo1 = 1, QzTiempo2 = 10, QzTiempo3 = 0;
        int AnTiempo1 = 1, AnTiempo2 = 10, AnTiempo3 = 0;
        int ZaTiempo1 = 1, ZaTiempo2 = 10, ZaTiempo3 = 0;
        int GnTiempo1 = 1, GnTiempo2 = 10, GnTiempo3 = 0;
        int CzTiempo1 = 1, CzTiempo2 = 10, CzTiempo3 = 0;
        int CaTiempo1 = 1, CaTiempo2 = 10, CaTiempo3 = 0;
        KeyboardState KBQz, KBAn, KBZa, KBGn, KBCz, KBCa;

        bool GameOver = false;
        Texture2D Win_Qz, Win_An, Win_Za, Win_Gn, Win_Cz, Win_Ca, Win_GameTime1, Win_GameTime2;
        int Ganador = 0, timeWin = 0;

        int BanderaEscenarios = 0;
        Texture2D PlataformaGameTime;
        Vector2 Pos_PlataformaGameTime;
        BoundingBox BPlataformaGameTime;

        Texture2D JugadorGameTime1, JugadorGameTime2;
        Vector2 pos_JugadorGameTime1, pos_JugadorGameTime2;
        BoundingBox BJugadorGameTime1, BJugadorGameTime2;

        SpriteFont FuenteVidaPlayer1, FuenteVidaPlayer2;
        int VidaPlayer1 = 500, VidaPlayer2 = 500;
        Vector2 Pos_BarraVida1, Pos_BarraVida2;
        Texture2D BarQuiroz1, BarAnaya1, BarZamarripa1, BarGuillen1, BarCanes1, BarCastruita1;
        Texture2D BarQuiroz2, BarAnaya2, BarZamarripa2, BarGuillen2, BarCanes2, BarCastruita2;


        Vector2 Pos_BarraAvilidad1, Pos_BarraAvilidad2;
        Texture2D BarAvQuiroz1, BarAvAnaya1, BarAvZamarripa1, BarAvGuillen1, BarAvCanes1, BarAvCastruita1;
        Texture2D BarAvQuiroz2, BarAvAnaya2, BarAvZamarripa2, BarAvGuillen2, BarAvCanes2, BarAvCastruita2;


        Vector2 pos_vida1, pos_vida2;
        Texture2D vida1, vida2, BarraGeneralP1, BarraGeneralP2, BarraAvilidadeGeneralP1, BarraAvilidadeGeneralP2;
        SpriteFont Fuente;
        SpriteFont P1FuenteQz, P2FuenteQz;
        SpriteFont P1FuenteAn, P2FuenteAn;
        SpriteFont P1FuenteZa, P2FuenteZa;
        SpriteFont P1FuenteGn, P2FuenteGn;
        SpriteFont P1FuenteCz, P2FuenteCz;
        SpriteFont P1FuenteCa, P2FuenteCa;
        //--------------------------------------------------------------------------------------------Escenarios//

        double tiempo;
        //MENU 1-----------------------------------------------------------------//
        KeyboardState kbM1;
        int menuState = 1, SelectorM1 = 1;
        Texture2D FondoMenu1;
        Texture2D Play, Salir, Tutorial, Creditos;
        Vector2 pos_play, pos_salir, pos_tutorial, pos_creditos;
        //-----------------------------------------------------------------MENU 1//

        //MENU 2-----------------------------------------------------------------//
        KeyboardState kbM2;
        int SelectorM2 = 1;
        Texture2D FondoMenu2;
        Texture2D botonQuiroz, botonAnaya, botonZamarripa, botonGuillen, botonCanes, botonCastruita, botonEsc, botonCancelar, botonAceptar;
        Vector2 pos_botonQuiroz, pos_botonAnaya, pos_botonZamarripa, pos_botonGuillen, pos_botonCanes, pos_botonCastruita, pos_botonEsc, pos_botonCancelar, pos_botonAceptar;
        int Player1 = 0, Player2 = 0;
        bool SeleccionarP1 = false, SeleccionarP2 = false;
        //-----------------------------------------------------------------MENU 2//

        //MENU 3-----------------------------------------------------------------//
        KeyboardState kbM3;
        int SelectorM3X = 1, SelectorM3Y = 1;
        Texture2D FondoMenu3;
        Random EcenarioRND;
        int RND = 0;
        Texture2D botonEcenarioRND, botonEcenario1, botonEcenario2, botonEcenario3, botonEcenario4, botonEcenario5;
        Vector2 pos_botonEcenarioRND, pos_botonEcenario1, pos_botonEcenario2, pos_botonEcenario3, pos_botonEcenario4, pos_botonEcenario5;
        int StageX = 0, StageY = 0;
        bool SeleccionarStage = false;
        //-----------------------------------------------------------------MENU 3//


        //Menu 5 Pausa-----------------------------------------------------------//
        KeyboardState kbM5;
        int SelectorM5 = 1;
        Texture2D MenuPausa, PausaVolver, PausaReiniciar, PausaMenu;
        //-----------------------------------------------------------Menu 5 Pausa//


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            Fuente = Content.Load<SpriteFont>("SpriteFont1");
            FuenteJugador1 = Content.Load<SpriteFont>("SpriteFont1");
            FuenteJugador2 = Content.Load<SpriteFont>("SpriteFont1");
            FuenteVidaPlayer1 = Content.Load<SpriteFont>("SpriteFont1");
            FuenteVidaPlayer2 = Content.Load<SpriteFont>("SpriteFont1");

            engine = new AudioEngine("Content\\sound\\sonido.xgs");
            soundBank = new SoundBank(engine, "Content\\sound\\Sound Bank.xsb");
            waveBank = new WaveBank(engine, "Content\\sound\\Wave Bank.xwb");

            cancion = soundBank.GetCue("DjKavi_Horntail");
            cancion.Play();

            //Barras de Vida----------------------------------------------------//
            Pos_BarraVida1 = new Vector2(28, 0);
            Pos_BarraVida2 = new Vector2(834, 0);
            pos_vida1 = new Vector2(834, 41);
            pos_vida2 = new Vector2(28, 41);

            BarQuiroz1 = Content.Load<Texture2D>("img/Barras/BarraVidaQuirozj1");
            BarQuiroz2 = Content.Load<Texture2D>("img/Barras/BarraVidaQuirozj2");
            BarAnaya1 = Content.Load<Texture2D>("img/Barras/BarraVidaAnayaj1");
            BarAnaya2 = Content.Load<Texture2D>("img/Barras/BarraVidaAnayaj2");
            BarZamarripa1 = Content.Load<Texture2D>("img/Barras/BarraVidaZamarripaj1");
            BarZamarripa2 = Content.Load<Texture2D>("img/Barras/BarraVidaZamarripaj2");
            BarGuillen1 = Content.Load<Texture2D>("img/Barras/BarraVidaGuillenj1");
            BarGuillen2 = Content.Load<Texture2D>("img/Barras/BarraVidaGuillenj2");
            BarCanes1 = Content.Load<Texture2D>("img/Barras/BarraVidaCanesj1");
            BarCanes2 = Content.Load<Texture2D>("img/Barras/BarraVidaCanesj2");
            BarCastruita1 = Content.Load<Texture2D>("img/Barras/BarraVidaCastruitaj1");
            BarCastruita2 = Content.Load<Texture2D>("img/Barras/BarraVidaCastruitaj2");
            vida1 = Content.Load<Texture2D>("img/Escenarios/Vida2");
            vida2 = Content.Load<Texture2D>("img/Escenarios/Vida1");
            //----------------------------------------------------Barras de Vida//


            //Barras de Avilidades----------------------------------------------------//
            Pos_BarraAvilidad1 = new Vector2(28, 645);
            Pos_BarraAvilidad2 = new Vector2(918, 645);

            BarAvQuiroz1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Quiroz");
            BarAvQuiroz2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Quiroz");
            BarAvAnaya1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Anaya");
            BarAvAnaya2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Anaya");
            BarAvZamarripa1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Zama");
            BarAvZamarripa2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Zama");
            BarAvGuillen1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Guillen");
            BarAvGuillen2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Guillen");
            BarAvCanes1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Canes");
            BarAvCanes2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Canes");
            BarAvCastruita1 = Content.Load<Texture2D>("img/InGame/Barra_J1_Castru");
            BarAvCastruita2 = Content.Load<Texture2D>("img/InGame/Barra_J2_Castru");

            P1FuenteQz = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteQz = Content.Load<SpriteFont>("SpriteFont2");
            P1FuenteAn = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteAn = Content.Load<SpriteFont>("SpriteFont2");
            P1FuenteZa = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteZa = Content.Load<SpriteFont>("SpriteFont2");
            P1FuenteGn = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteGn = Content.Load<SpriteFont>("SpriteFont2");
            P1FuenteCz = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteCz = Content.Load<SpriteFont>("SpriteFont2");
            P1FuenteCa = Content.Load<SpriteFont>("SpriteFont2");
            P2FuenteCa = Content.Load<SpriteFont>("SpriteFont2");
            //----------------------------------------------------Barras de Avilidades//

            //Panatllas de fin de la partida------------------------------------------//
            Win_Qz = Content.Load<Texture2D>("img/InGame/PantallaWinQuiroz");
            Win_An = Content.Load<Texture2D>("img/InGame/PantallaWinAnaya");
            Win_Za = Content.Load<Texture2D>("img/InGame/PantallaWinZamarripa");
            Win_Gn = Content.Load<Texture2D>("img/InGame/PantallaWinGuillen");
            Win_Cz = Content.Load<Texture2D>("img/InGame/PantallaWinCanez");
            Win_Ca = Content.Load<Texture2D>("img/InGame/PantallaWinCastruita");
            //------------------------------------------Panatllas de fin de la partida//


            //Herencia de todos los objetos de los Escenarios---------------------------------------//
            Texture2D FondoM1 = Content.Load<Texture2D>("img/Escenarios/FondoTorneo");
            Texture2D FondoM2 = Content.Load<Texture2D>("img/Escenarios/FondoSweetVictory");
            Texture2D FondoM3 = Content.Load<Texture2D>("img/Escenarios/FondoFuego");
            Texture2D FondoM4 = Content.Load<Texture2D>("img/Escenarios/FondoCity");
            Texture2D FondoM5 = Content.Load<Texture2D>("img/Escenarios/FondoLunar");

            Vector2 pos_Plataforma1 = new Vector2(16, 588);
            Vector2 pos_Plataforma2 = new Vector2(40, 623);
            Vector2 pos_Plataforma3 = new Vector2(77, 630);
            Vector2 pos_Plataforma4 = new Vector2(27, 583);
            Vector2 pos_Plataforma5 = new Vector2(109, 573);

            Texture2D Plataforma1 = Content.Load<Texture2D>("img/Escenarios/PlataformaM1");
            Texture2D Plataforma2 = Content.Load<Texture2D>("img/Escenarios/PlataformaM2");
            Texture2D Plataforma3 = Content.Load<Texture2D>("img/Escenarios/PlataformaM3");
            Texture2D Plataforma4 = Content.Load<Texture2D>("img/Escenarios/PlataformaM4");
            Texture2D Plataforma5 = Content.Load<Texture2D>("img/Escenarios/PlataformaM5");

            escenario1 = new Escenario1(FondoM1, pos_Plataforma1, Plataforma1);
            escenario2 = new Escenario2(FondoM2, pos_Plataforma2, Plataforma2);
            escenario3 = new Escenario3(FondoM3, pos_Plataforma3, Plataforma3);
            escenario4 = new Escenario4(FondoM4, pos_Plataforma4, Plataforma4);
            escenario5 = new Escenario5(FondoM5, pos_Plataforma5, Plataforma5);
            //---------------------------------------Herencia de todos los objetos de los Escenarios//


            //Texturas Quiroz---------------------------------------------------------------------------//
            PQuiroz = new Vector2(900, 250);
            QzUSB1 = Content.Load<Texture2D>("img/Quiroz/Disparo_Der");
            Quiroz_Der = Content.Load<Texture2D>("img/Quiroz/Quiroz_Der");
            Quiroz_Run_Der1 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Der1");
            Quiroz_Run_Der2 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Der2");
            Quiroz_Run_Der3 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Der3");
            Quiroz_Jump_Der = Content.Load<Texture2D>("img/Quiroz/Quiroz_Jump_Der");
            Quiroz_Attac1_Der = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac1_Der");
            Quiroz_Attac2_Der = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac2_Der");
            Quiroz_Attac3_Der = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac3_Der");
            

            QzUSB2 = Content.Load<Texture2D>("img/Quiroz/Disparo_Izq");
            Quiroz_Izq = Content.Load<Texture2D>("img/Quiroz/Quiroz_Izq");
            Quiroz_Run_Izq1 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Izq1");
            Quiroz_Run_Izq2 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Izq2");
            Quiroz_Run_Izq3 = Content.Load<Texture2D>("img/Quiroz/Quiroz_Run_Izq3");
            Quiroz_Jump_Izq = Content.Load<Texture2D>("img/Quiroz/Quiroz_Jump_Izq");
            Quiroz_Attac1_Izq = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac1_Izq");
            Quiroz_Attac2_Izq = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac2_Izq");
            Quiroz_Attac3_Izq = Content.Load<Texture2D>("img/Quiroz/Quiroz_Attac3_Izq");

            TQuiroz = Quiroz_Der;
            caeQZ = false;
            masaQZ = 5f;
            tiemposueltoQZ = 0;
            timeUPQZ = 0.05f;
            //---------------------------------------------------------------------------Texturas Quiroz//



            //Texturas Anaya---------------------------------------------------------------------------//
            PAnaya = new Vector2(900, 250);
            AnayaPI = Content.Load<Texture2D>("img/Anaya/disparo");
            Anaya_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Der");
            Anaya_Run_Der1 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Der1");
            Anaya_Run_Der2 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Der2");
            Anaya_Run_Der3 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Der3");
            Anaya_Run_Der4 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Der2");
            Anaya_Jump_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Jump_Der");
            Anaya_Attac1_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Attac1_Der");
            Anaya_Attac2_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Attac2_Der");
            Anaya_Attac3_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Attac3_Der");
            Anaya_Ulti_Der = Content.Load<Texture2D>("img/Anaya/Anaya_Ulti_Der");


            Anaya_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Izq");
            Anaya_Run_Izq1 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Izq1");
            Anaya_Run_Izq2 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Izq2");
            Anaya_Run_Izq3 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Izq3");
            Anaya_Run_Izq4 = Content.Load<Texture2D>("img/Anaya/Anaya_Run_Izq2");
            Anaya_Jump_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Jump_Izq");
            Anaya_Attac1_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Attac1_Izq");
            Anaya_Attac2_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Attac2_Izq");
            Anaya_Attac3_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Attac3_Izq");
            Anaya_Ulti_Izq = Content.Load<Texture2D>("img/Anaya/Anaya_Ulti_Izq");

            Rayos1 = Content.Load<Texture2D>("img/Anaya/Rayos1");
            pos_Rayos = new Vector2(100, -25);

            TAnaya = Anaya_Der;
            caeAn = false;
            masaAn = 5f;
            tiemposueltoAn = 0;
            timeUPAn = 0.05f;
            //---------------------------------------------------------------------------Texturas Anaya//




            //Texturas Zamarripa------------------------------------------------------------------------//
            PZama = new Vector2(300, 200);
            Baston_Der = Content.Load<Texture2D>("img/Zamarripa/Baston_Der");
            Zamarripa_Der = Content.Load<Texture2D>("img/Zamarripa/Zama_Der");
            Zamarripa_Run_Der1 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Der1");
            Zamarripa_Run_Der2 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Der2");
            Zamarripa_Run_Der3 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Der3");
            Zamarripa_Run_Der4 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Der2");
            Zamarripa_Jump_Der = Content.Load<Texture2D>("img/Zamarripa/Zama_Jump_Der");
            Zamarripa_Attac1_Der = Content.Load<Texture2D>("img/Zamarripa/Zama_Attac1_Der");
            Zamarripa_Attac2_Der = Content.Load<Texture2D>("img/Zamarripa/Zama_Attac2_Der");

            Baston_Izq = Content.Load<Texture2D>("img/Zamarripa/Baston_Izq");
            Zamarripa_Izq = Content.Load<Texture2D>("img/Zamarripa/Zama_Izq");
            Zamarripa_Run_Izq1 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Izq1");
            Zamarripa_Run_Izq2 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Izq2");
            Zamarripa_Run_Izq3 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Izq3");
            Zamarripa_Run_Izq4 = Content.Load<Texture2D>("img/Zamarripa/Zama_Run_Izq2");
            Zamarripa_Jump_Izq = Content.Load<Texture2D>("img/Zamarripa/Zama_Jump_Izq");
            Zamarripa_Attac1_Izq = Content.Load<Texture2D>("img/Zamarripa/Zama_Attac1_Izq");
            Zamarripa_Attac2_Izq = Content.Load<Texture2D>("img/Zamarripa/Zama_Attac2_Izq");
            //Ulti Zamarripa----------------------------------------------------------------//
            UltiBaston_Der = Content.Load<Texture2D>("img/Zamarripa/Ulti/Baston_Der");
            UltiZamarripa_Der = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Der");
            UltiZamarripa_Run_Der1 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Der1");
            UltiZamarripa_Run_Der2 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Der2");
            UltiZamarripa_Run_Der3 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Der3");
            UltiZamarripa_Run_Der4 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Der2");
            UltiZamarripa_Jump_Der = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Jump_Der");
            UltiZamarripa_Attac1_Der = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Attac1_Der");
            UltiZamarripa_Attac2_Der = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Attac2_Der");

            UltiBaston_Izq = Content.Load<Texture2D>("img/Zamarripa/Ulti/Baston_Izq");
            UltiZamarripa_Izq = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Izq");
            UltiZamarripa_Run_Izq1 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Izq1");
            UltiZamarripa_Run_Izq2 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Izq2");
            UltiZamarripa_Run_Izq3 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Izq3");
            UltiZamarripa_Run_Izq4 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Run_Izq2");
            UltiZamarripa_Jump_Izq = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Jump_Izq");
            UltiZamarripa_Attac1_Izq = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Attac1_Izq");
            UltiZamarripa_Attac2_Izq = Content.Load<Texture2D>("img/Zamarripa/Ulti/Zama_Attac2_Izq");
            //----------------------------------------------------------------Ulti Zamarripa//

            TZama = Zamarripa_Der;
            GanchoDer = Content.Load<Texture2D>("img/Zamarripa/GanchoDer");
            GanchoIzq = Content.Load<Texture2D>("img/Zamarripa/GanchoIzq");
            UltiGanchoDer = Content.Load<Texture2D>("img/Zamarripa/Ulti/GanchoDer");
            UltiGanchoIzq = Content.Load<Texture2D>("img/Zamarripa/Ulti/GanchoIzq");
            pos_Gancho = new Vector2(PZama.X, PZama.Y - 130);
            caeZA = false;
            masaZA = 5f;
            tiemposueltoZA = 0;
            timeUPZA = 0.05f;
            //------------------------------------------------------------------------Texturas Zamarripa//




            //Texturas Guillen------------------------------------------------------------------------//
            PGuillen = new Vector2(300, 200);
            Guillen_Der = Content.Load<Texture2D>("img/Guillen/Guillen_Der");
            Guillen_Run_Der1 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Der1");
            Guillen_Run_Der2 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Der2");
            Guillen_Run_Der3 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Der3");
            Guillen_Run_Der4 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Der2");
            Guillen_Jump_Der = Content.Load<Texture2D>("img/Guillen/Guillen_Jump_Der");
            Guillen_Attac1_Der = Content.Load<Texture2D>("img/Guillen/Guillen_Attac1_Der");
            Guillen_Attac2_Der = Content.Load<Texture2D>("img/Guillen/Guillen_Attac2_Der");


            Guillen_Izq = Content.Load<Texture2D>("img/Guillen/Guillen_Izq");
            Guillen_Run_Izq1 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Izq1");
            Guillen_Run_Izq2 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Izq2");
            Guillen_Run_Izq3 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Izq3");
            Guillen_Run_Izq4 = Content.Load<Texture2D>("img/Guillen/Guillen_Run_Izq2");
            Guillen_Jump_Izq = Content.Load<Texture2D>("img/Guillen/Guillen_Jump_Izq");
            Guillen_Attac1_Izq = Content.Load<Texture2D>("img/Guillen/Guillen_Attac1_Izq");
            Guillen_Attac2_Izq = Content.Load<Texture2D>("img/Guillen/Guillen_Attac2_Izq");

            Reloj = Content.Load<Texture2D>("img/Guillen/reloj");
            pos_reloj = new Vector2(PGuillen.X, PGuillen.Y - 130);
            TGuillen = Guillen_Der;
            caeGn = false;
            masaGn = 5f;
            tiemposueltoGn = 0;
            timeUPGn = 0.05f;
            //------------------------------------------------------------------------Texturas Guillen//





            //Texturas Cañez---------------------------------------------------------------------------//
            PCanez = new Vector2(900, 250);
            Gema = Content.Load<Texture2D>("img/Canez/Gema");
            Canez_Der = Content.Load<Texture2D>("img/Canez/Canez_Der");
            Canez_Run_Der1 = Content.Load<Texture2D>("img/Canez/Canez_Run_Der1");
            Canez_Run_Der2 = Content.Load<Texture2D>("img/Canez/Canez_Run_Der2");
            Canez_Run_Der3 = Content.Load<Texture2D>("img/Canez/Canez_Run_Der3");
            Canez_Run_Der4 = Content.Load<Texture2D>("img/Canez/Canez_Run_Der4");
            Canez_Run_Der5 = Content.Load<Texture2D>("img/Canez/Canez_Run_Der2");
            Canez_Jump_Der = Content.Load<Texture2D>("img/Canez/Canez_Jump_Der");
            Canez_Attac1_Der = Content.Load<Texture2D>("img/Canez/Canez_Attac2_Der");
            Canez_Attac2_Der = Content.Load<Texture2D>("img/Canez/Canez_Attac2_Der");
            Canez_Attac3_Der = Content.Load<Texture2D>("img/Canez/Canez_Attac3_Der");
            Canez_Ulti_Der = Content.Load<Texture2D>("img/Canez/Canez_Ulti_Der");

            Canez_Izq = Content.Load<Texture2D>("img/Canez/Canez_Izq");
            Canez_Run_Izq1 = Content.Load<Texture2D>("img/Canez/Canez_Run_Izq1");
            Canez_Run_Izq2 = Content.Load<Texture2D>("img/Canez/Canez_Run_Izq2");
            Canez_Run_Izq3 = Content.Load<Texture2D>("img/Canez/Canez_Run_Izq3");
            Canez_Run_Izq4 = Content.Load<Texture2D>("img/Canez/Canez_Run_Izq4");
            Canez_Run_Izq5 = Content.Load<Texture2D>("img/Canez/Canez_Run_Izq2");
            Canez_Jump_Izq = Content.Load<Texture2D>("img/Canez/Canez_Jump_Izq");
            Canez_Attac1_Izq = Content.Load<Texture2D>("img/Canez/Canez_Attac2_Izq");
            Canez_Attac2_Izq = Content.Load<Texture2D>("img/Canez/Canez_Attac2_Izq");
            Canez_Attac3_Izq = Content.Load<Texture2D>("img/Canez/Canez_Attac3_Izq");
            Canez_Ulti_Izq = Content.Load<Texture2D>("img/Canez/Canez_Ulti_Izq");

            TCanez = Canez_Der;
            caeCz = false;
            masaCz = 5f;
            tiemposueltoCz = 0;
            timeUPCz = 0.05f;
            //---------------------------------------------------------------------------Texturas Cañez//




            //Texturas Castruita------------------------------------------------------------------------//
            PCastru = new Vector2(300, 200);
            Castru_Der = Content.Load<Texture2D>("img/Castruita/Castru_Der");
            Castru_Run_Der1 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Der1");
            Castru_Run_Der2 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Der2");
            Castru_Run_Der3 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Der3");
            Castru_Run_Der4 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Der2");
            Castru_Jump_Der = Content.Load<Texture2D>("img/Castruita/Castru_Jump_Der");
            Castru_Attac2_Der = Content.Load<Texture2D>("img/Castruita/Castru_Attac2_Der");
            Castru_Attac3_Der = Content.Load<Texture2D>("img/Castruita/Castru_Ulti_Der");


            Castru_Izq = Content.Load<Texture2D>("img/Castruita/Castru_Izq");
            Castru_Run_Izq1 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Izq1");
            Castru_Run_Izq2 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Izq2");
            Castru_Run_Izq3 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Izq3");
            Castru_Run_Izq4 = Content.Load<Texture2D>("img/Castruita/Castru_Run_Izq2");
            Castru_Jump_Izq = Content.Load<Texture2D>("img/Castruita/Castru_Jump_Izq");
            Castru_Attac2_Izq = Content.Load<Texture2D>("img/Castruita/Castru_Attac2_Izq");
            Castru_Attac3_Izq = Content.Load<Texture2D>("img/Castruita/Castru_Ulti_Izq");

            GranoCafe = Content.Load<Texture2D>("img/Castruita/GranoCafe");
            explocion = Content.Load<Texture2D>("img/Castruita/Explocion");
            pos_GranoCafe = new Vector2(PCastru.X, PCastru.Y);
            TCastru = Castru_Der;
            caeCa = false;
            masaCa = 5f;
            tiemposueltoCa = 0;
            timeUPCa = 0.05f;
            //------------------------------------------------------------------------Texturas Castruita//
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Quiroz-------------------------------------------------------------------//
            disparoDerQZ.disparoDerQZ = QzUSB1;
            disparoIzqQZ.disparoIzqQZ = QzUSB2;

            disparoDerQZ.posDisparoDerQZ = new Vector2(PQuiroz.X, PQuiroz.Y);
            disparoDerQZ.velDiaparoDerQZ = 2.0f;
            ListaDisparosDerQZ = new List<DatosDisparoDerQZ>();

            disparoIzqQZ.posDisparoIzqQZ = new Vector2(PQuiroz.X, PQuiroz.Y);
            disparoIzqQZ.velDiaparoIzqQZ = -2.0f;
            ListaDisparosIzqQZ = new List<DatosDisparoIzqQZ>();

            //ULTI DE QUIROZ------------------------------------------------------//
            ListaDisparosUltiIzq = new List<DatosDisparoUltiIzq>();
            disparoUltiIzq.posRayoUltiIzq = new Vector2(PQuiroz.X, PQuiroz.Y + 50);
            disparoUltiIzq.rotacionUltiIzq = 0.5f;
            disparoUltiIzq.velRayoUltiIzq = 2.0f;
            disparoUltiIzq.rayoUltiIzq = Content.Load<Texture2D>("img/Quiroz/Rayo");


            ListaDisparosUltiDer = new List<DatosDisparoUltiDer>();
            disparoUltiDer.posRayoUltiDer = new Vector2(PQuiroz.X + TQuiroz.Width, PQuiroz.Y + 50);
            disparoUltiDer.rotacionUltiDer = 0.5f;
            disparoUltiDer.velRayoUltiDer = 2.0f;
            disparoUltiDer.rayoUltiDer = Content.Load<Texture2D>("img/Quiroz/Rayo");
            //------------------------------------------------------ULTI DE QUIROZ//

            //-------------------------------------------------------------------Quiroz//
            //Anaya-------------------------------------------------------------------//
            disparoDerAn.disparoDerAn = Content.Load<Texture2D>("img/Anaya/disparo");
            disparoIzqAn.disparoIzqAn = Content.Load<Texture2D>("img/Anaya/disparo");

            disparoDerAn.posDisparoDerAn = new Vector2(PAnaya.X, PAnaya.Y);
            disparoDerAn.velDiaparoDerAn = 2.0f;
            ListaDisparosDerAn = new List<DatosDisparoDerAn>();

            disparoIzqAn.posDisparoIzqAn = new Vector2(PAnaya.X, PAnaya.Y);
            disparoIzqAn.velDiaparoIzqAn = -2.0f;
            ListaDisparosIzqAn = new List<DatosDisparoIzqAn>();
            //-------------------------------------------------------------------Anaya//
            //Zamarripa----------------------------------------------------------------//
            ListaDisparos1 = new List<DatosDisparo1>();
            disparo1.posRayo1 = new Vector2(PZama.X, PZama.Y + 50);
            disparo1.rotacion1 = 0.5f;
            disparo1.velRayo1 = 2.0f;
            disparo1.rayo1 = Content.Load<Texture2D>("img/Zamarripa/Baston_Izq");
            disparo1.Ultirayo1 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Baston_Izq");


            ListaDisparos2 = new List<DatosDisparo2>();
            disparo2.posRayo2 = new Vector2(PZama.X + TZama.Width, PZama.Y + 50);
            disparo2.rotacion2 = 0.5f;
            disparo2.velRayo2 = 2.0f;
            disparo2.rayo2 = Content.Load<Texture2D>("img/Zamarripa/Baston_Der");
            disparo2.Ultirayo2 = Content.Load<Texture2D>("img/Zamarripa/Ulti/Baston_Der");
            //----------------------------------------------------------------Zamarripa//
            //Guillen----------------------------------------------------------------//
            ListaDisparos_IzqGn = new List<DatosDisparo_IzqGn>();
            disparo_IzqGn.posRayo_IzqGn = new Vector2(PGuillen.X, PGuillen.Y + 50);
            disparo_IzqGn.rotacion_IzqGn = 0.5f;
            disparo_IzqGn.velRayo_IzqGn = 2.0f;
            disparo_IzqGn.rayo_IzqGn = Content.Load<Texture2D>("img/Guillen/Borrador");


            ListaDisparos_DerGn = new List<DatosDisparo_DerGn>();
            disparo_DerGn.posRayo_DerGn = new Vector2(PGuillen.X + TGuillen.Width, PGuillen.Y + 50);
            disparo_DerGn.rotacion_DerGn = 0.5f;
            disparo_DerGn.velRayo_DerGn = 2.0f;
            disparo_DerGn.rayo_DerGn = Content.Load<Texture2D>("img/Guillen/Borrador");
            //----------------------------------------------------------------Guillen//
            //Cañez-------------------------------------------------------------------//
            disparoDerCz.disparoDerCz = Gema;
            disparoIzqCz.disparoIzqCz = Gema;

            disparoDerCz.posDisparoDerCz = new Vector2(PCanez.X, PCanez.Y);
            disparoDerCz.velDiaparoDerCz = 2.0f;
            ListaDisparosDerCz = new List<DatosDisparoDerCz>();

            disparoIzqCz.posDisparoIzqCz = new Vector2(PCanez.X, PCanez.Y);
            disparoIzqCz.velDiaparoIzqCz = -2.0f;
            ListaDisparosIzqCz = new List<DatosDisparoIzqCz>();
            //-------------------------------------------------------------------Cañez//
            //Castruita----------------------------------------------------------------//
            ListaDisparos_IzqCa = new List<DatosDisparo_IzqCa>();
            disparo_IzqCa.posRayo_IzqCa = new Vector2(PCastru.X, PCastru.Y + 50);
            disparo_IzqCa.rotacion_IzqCa = 0.5f;
            disparo_IzqCa.velRayo_IzqCa = 2.0f;
            disparo_IzqCa.rayo_IzqCa = Content.Load<Texture2D>("img/Castruita/Cafe");


            ListaDisparos_DerCa = new List<DatosDisparo_DerCa>();
            disparo_DerCa.posRayo_DerCa = new Vector2(PCastru.X + TCastru.Width, PCastru.Y + 50);
            disparo_DerCa.rotacion_DerCa = 0.5f;
            disparo_DerCa.velRayo_DerCa = 2.0f;
            disparo_DerCa.rayo_DerCa = Content.Load<Texture2D>("img/Castruita/Cafe");
            //----------------------------------------------------------------Castruita//
            


            //MENU 1-----------------------------------------------------------------//
            FondoMenu1 = Content.Load<Texture2D>("img/Menu/Menu1");

            Play = Content.Load<Texture2D>("img/Menu/play");
            Salir = Content.Load<Texture2D>("img/Menu/salir");
            Tutorial = Content.Load<Texture2D>("img/Menu/tutorial");
            Creditos = Content.Load<Texture2D>("img/Menu/creditos");

            pos_play = new Vector2(550, 200);
            pos_tutorial = new Vector2(550, 300);
            pos_creditos = new Vector2(550, 400);
            pos_salir = new Vector2(550, 500);
            //-----------------------------------------------------------------MENU 1//

            //MENU 2-----------------------------------------------------------------//
            FondoMenu2 = Content.Load<Texture2D>("img/Menu/Menu2");

            botonQuiroz = Content.Load<Texture2D>("img/Menu/boton_Quiroz");
            botonAnaya = Content.Load<Texture2D>("img/Menu/boton_Anaya");
            botonZamarripa = Content.Load<Texture2D>("img/Menu/boton_Zamarripa");
            botonGuillen = Content.Load<Texture2D>("img/Menu/boton_Guillen");
            botonCanes = Content.Load<Texture2D>("img/Menu/boton_Canes");
            botonCastruita = Content.Load<Texture2D>("img/Menu/boton_Castruita");
            botonEsc = Content.Load<Texture2D>("img/Menu/Esc_volver");
            botonCancelar = Content.Load<Texture2D>("img/Menu/cancelar");
            botonAceptar = Content.Load<Texture2D>("img/Menu/aceptar");

            pos_botonQuiroz = new Vector2(185, 135);
            pos_botonAnaya = new Vector2(387, 135);
            pos_botonZamarripa = new Vector2(387, 384);

            pos_botonGuillen = new Vector2(793, 135);
            pos_botonCanes = new Vector2(995, 135);
            pos_botonCastruita = new Vector2(793, 384);

            pos_botonEsc = new Vector2(50, 700);
            pos_botonCancelar = new Vector2(650, 700);
            pos_botonAceptar = new Vector2(1000, 700);
            //-----------------------------------------------------------------MENU 2//

            //MENU 3-----------------------------------------------------------------//
            FondoMenu3 = Content.Load<Texture2D>("img/Menu/Menu3");

            botonEcenarioRND = Content.Load<Texture2D>("img/Menu/EsenarioRND");
            botonEcenario1 = Content.Load<Texture2D>("img/Menu/Esenario1");
            botonEcenario2 = Content.Load<Texture2D>("img/Menu/Esenario2");
            botonEcenario3 = Content.Load<Texture2D>("img/Menu/Esenario3");
            botonEcenario4 = Content.Load<Texture2D>("img/Menu/Esenario4");
            botonEcenario5 = Content.Load<Texture2D>("img/Menu/Esenario5");

            pos_botonEcenario1 = new Vector2(180, 132);
            pos_botonEcenario2 = new Vector2(780, 132);
            pos_botonEcenario3 = new Vector2(180, 310);
            pos_botonEcenario4 = new Vector2(780, 310);
            pos_botonEcenario5 = new Vector2(180, 494);
            pos_botonEcenarioRND = new Vector2(780, 494);
            //-----------------------------------------------------------------MENU 3//

            //MENU 5-----------------------------------------------------------------//
            MenuPausa = Content.Load<Texture2D>("img/Menu/Menu5_Pausa");

            PausaVolver = Content.Load<Texture2D>("img/Menu/boton_volver2");
            PausaReiniciar = Content.Load<Texture2D>("img/Menu/boton_reiniciar");
            PausaMenu = Content.Load<Texture2D>("img/Menu/boton_menu");

            pos_play = new Vector2(550, 200);
            pos_tutorial = new Vector2(550, 300);
            pos_creditos = new Vector2(550, 400);
            //-----------------------------------------------------------------MENU 5//
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            tiempo = gameTime.TotalGameTime.Milliseconds;
            EcenarioRND = new Random();
            //Menu numero 1
            if (menuState == 1)
            {
                TiempoUlti = 0;
                TiempoDash = 0;
                DashAnaya = 0;
                TiempoTodoPoderos = 0;
                TiempoStormBreaker = 0;
                TiempoInvicible = 0;
                ChasquidoCz = false;
                CastruHab2 = 0;
                TiempoCafeina = 0;
                SpownQz = 0;
                SpownAn = 0;
                SpownZa = 0;
                SpownGn = 0;
                SpownCz = 0;
                SpownCa = 0;
                QzTiempo1 = 1;
                QzTiempo2 = 10;
                QzTiempo3 = 0;
                AnTiempo1 = 1;
                AnTiempo2 = 10;
                AnTiempo3 = 0;
                ZaTiempo1 = 1;
                ZaTiempo2 = 10;
                ZaTiempo3 = 0;
                GnTiempo1 = 1;
                GnTiempo2 = 10;
                GnTiempo3 = 0;
                CzTiempo1 = 1;
                CzTiempo2 = 10;
                CzTiempo3 = 0;
                CaTiempo1 = 1;
                CaTiempo2 = 10;
                CaTiempo3 = 0;
                GameOver = false;
                Ganador = 0;
                pos_vida1 = new Vector2(834, 41);
                pos_vida2 = new Vector2(28, 41);

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && !(kbM1.IsKeyDown(Keys.Up)))
                {
                    SelectorM1--;
                    if (SelectorM1 < 1)
                    {
                        SelectorM1 = 4;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && !(kbM1.IsKeyDown(Keys.Down)))
                {
                    SelectorM1++;
                    if (SelectorM1 > 4)
                    {
                        SelectorM1 = 1;
                    }
                }


                if (SelectorM1 == 1 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM1.IsKeyDown(Keys.Enter)))
                    menuState = 2;

                if (SelectorM1 == 2 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM1.IsKeyDown(Keys.Enter)))
                    menuState = -1;

                if (SelectorM1 == 4 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM1.IsKeyDown(Keys.Enter)))
                    this.Exit();

                kbM1 = Keyboard.GetState();
            }

            //Menu numero 2
            if (menuState == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(kbM2.IsKeyDown(Keys.Right)))
                {
                    SelectorM2++;
                    if (SelectorM2 > 6)
                    {
                        SelectorM2 = 1;
                    }
                    if (SelectorM2 == Player1)
                        SelectorM2++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(kbM2.IsKeyDown(Keys.Left)))
                {
                    SelectorM2--;
                    if (SelectorM2 < 1)
                    {
                        SelectorM2 = 6;
                    }
                    if (SelectorM2 == Player1)
                        SelectorM2--;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !(kbM2.IsKeyDown(Keys.Escape)))
                {
                    menuState = 1;

                    SeleccionarP1 = false;
                    SeleccionarP2 = false;
                    Player1 = 0;
                    Player2 = 0;
                    SelectorM2 = 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.C) && !(kbM2.IsKeyDown(Keys.C)))
                {
                    SeleccionarP1 = false;
                    SeleccionarP2 = false;
                    Player1 = 0;
                    Player2 = 0;
                    SelectorM2 = 1;
                }

                //Cuado preciones enter y seleccione a los 2 jugadores----------------------------------//
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !(kbM2.IsKeyDown(Keys.E)) && Player1 == 0)
                {
                    SeleccionarP1 = true;
                    Player1 = SelectorM2;
                    SelectorM2 = 1;
                    if (Player1 == 1)
                        SelectorM2++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.R) && !(kbM2.IsKeyDown(Keys.R)) && Player1 != 0)
                {
                    SeleccionarP2 = true;
                    Player2 = SelectorM2;
                    SelectorM2 = 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM2.IsKeyDown(Keys.Enter)) && Player1 != 0 && Player2 != 0)
                {
                    //PLayer 1--------------------------------------------------------------
                    if (Player2 == 1)
                    {
                        BarraGeneralP1 = BarQuiroz1;
                        BarraAvilidadeGeneralP1 = BarAvQuiroz1;
                        Win_GameTime2 = Win_Qz;
                    }

                    if (Player2 == 2)
                    {
                        BarraGeneralP1 = BarAnaya1;
                        BarraAvilidadeGeneralP1 = BarAvAnaya1;
                        Win_GameTime2 = Win_An;
                    }

                    if (Player2 == 3)
                    {
                        BarraGeneralP1 = BarZamarripa1;
                        BarraAvilidadeGeneralP1 = BarAvZamarripa1;
                        Win_GameTime2 = Win_Za;
                    }

                    if (Player2 == 4)
                    {
                        BarraGeneralP1 = BarGuillen1;
                        BarraAvilidadeGeneralP1 = BarAvGuillen1;
                        Win_GameTime2 = Win_Gn;
                    }

                    if (Player2 == 5)
                    {
                        BarraGeneralP1 = BarCanes1;
                        BarraAvilidadeGeneralP1 = BarAvCanes1;
                        Win_GameTime2 = Win_Cz;
                    }

                    if (Player2 == 6)
                    {
                        BarraGeneralP1 = BarCastruita1;
                        BarraAvilidadeGeneralP1 = BarAvCastruita1;
                        Win_GameTime2 = Win_Ca;
                    }

                    //PLayer 2--------------------------------------------------------------
                    if (Player1 == 1)
                    {
                        BarraGeneralP2 = BarQuiroz2;
                        BarraAvilidadeGeneralP2 = BarAvQuiroz2;
                        Win_GameTime1 = Win_Qz;
                    }

                    if (Player1 == 2)
                    {
                        BarraGeneralP2 = BarAnaya2;
                        BarraAvilidadeGeneralP2 = BarAvAnaya2;
                        Win_GameTime1 = Win_An;
                    }

                    if (Player1 == 3)
                    {
                        BarraGeneralP2 = BarZamarripa2;
                        BarraAvilidadeGeneralP2 = BarAvZamarripa2;
                        Win_GameTime1 = Win_Za;
                    }

                    if (Player1 == 4)
                    {
                        BarraGeneralP2 = BarGuillen2;
                        BarraAvilidadeGeneralP2 = BarAvGuillen2;
                        Win_GameTime1 = Win_Gn;
                    }

                    if (Player1 == 5)
                    {
                        BarraGeneralP2 = BarCanes2;
                        BarraAvilidadeGeneralP2 = BarAvCanes2;
                        Win_GameTime1 = Win_Cz;
                    }

                    if (Player1 == 6)
                    {
                        BarraGeneralP2 = BarCastruita2;
                        BarraAvilidadeGeneralP2 = BarAvCastruita2;
                        Win_GameTime1 = Win_Ca;
                    }

                    menuState = 3;
                }
                //----------------------------------Cuado preciones enter y seleccione a los 2 jugadores//
                kbM2 = Keyboard.GetState();
            }

            //-----------------------------------------------------------------------------------------------------------//
            //Menu De informacion de los personajes
            if (menuState == -1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(kbM2.IsKeyDown(Keys.Right)))
                {
                    SelectorM2++;
                    if (SelectorM2 > 6)
                    {
                        SelectorM2 = 1;
                    }
                    if (SelectorM2 == Player1)
                        SelectorM2++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(kbM2.IsKeyDown(Keys.Left)))
                {
                    SelectorM2--;
                    if (SelectorM2 < 1)
                    {
                        SelectorM2 = 6;
                    }
                    if (SelectorM2 == Player1)
                        SelectorM2--;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !(kbM2.IsKeyDown(Keys.Escape)))
                {
                    menuState = 1;

                    SeleccionarP1 = false;
                    SeleccionarP2 = false;
                    Player1 = 0;
                    Player2 = 0;
                    SelectorM2 = 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.C) && !(kbM2.IsKeyDown(Keys.C)))
                {
                    SeleccionarP1 = false;
                    SeleccionarP2 = false;
                    Player1 = 0;
                    Player2 = 0;
                    SelectorM2 = 1;
                }

                //Cuado preciones enter y seleccione a los 2 jugadores----------------------------------//
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !(kbM2.IsKeyDown(Keys.E)) && Player1 == 0)
                {
                    SeleccionarP1 = true;
                    Player1 = SelectorM2;
                    SelectorM2 = 1;
                    if (Player1 == 1)
                        SelectorM2++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM2.IsKeyDown(Keys.Enter)) && Player1 != 0 && Player2 != 0)
                {
                    //PLayer 1--------------------------------------------------------------
                    if (Player2 == 1)
                    {
                        BarraGeneralP1 = BarQuiroz1;
                        BarraAvilidadeGeneralP1 = BarAvQuiroz1;
                    }

                    if (Player2 == 2)
                    {
                        BarraGeneralP1 = BarAnaya1;
                        BarraAvilidadeGeneralP1 = BarAvAnaya1;
                    }

                    if (Player2 == 3)
                    {
                        BarraGeneralP1 = BarZamarripa1;
                        BarraAvilidadeGeneralP1 = BarAvZamarripa1;
                    }

                    if (Player2 == 4)
                    {
                        BarraGeneralP1 = BarGuillen1;
                        BarraAvilidadeGeneralP1 = BarAvGuillen1;
                    }

                    if (Player2 == 5)
                    {
                        BarraGeneralP1 = BarCanes1;
                        BarraAvilidadeGeneralP1 = BarAvCanes1;
                    }

                    if (Player2 == 6)
                    {
                        BarraGeneralP1 = BarCastruita1;
                        BarraAvilidadeGeneralP1 = BarAvCastruita1;
                    }

                    //PLayer 2--------------------------------------------------------------
                    if (Player1 == 1)
                    {
                        BarraGeneralP2 = BarQuiroz2;
                        BarraAvilidadeGeneralP2 = BarAvQuiroz2;
                    }

                    if (Player1 == 2)
                    {
                        BarraGeneralP2 = BarAnaya2;
                        BarraAvilidadeGeneralP2 = BarAvAnaya2;
                    }

                    if (Player1 == 3)
                    {
                        BarraGeneralP2 = BarZamarripa2;
                        BarraAvilidadeGeneralP2 = BarAvZamarripa2;
                    }

                    if (Player1 == 4)
                    {
                        BarraGeneralP2 = BarGuillen2;
                        BarraAvilidadeGeneralP2 = BarAvGuillen2;
                    }

                    if (Player1 == 5)
                    {
                        BarraGeneralP2 = BarCanes2;
                        BarraAvilidadeGeneralP2 = BarAvCanes2;
                    }

                    if (Player1 == 6)
                    {
                        BarraGeneralP2 = BarCastruita2;
                        BarraAvilidadeGeneralP2 = BarAvCastruita2;
                    }

                    menuState = 3;
                }
                //----------------------------------Cuando preciones enter y seleccione a los 2 jugadores//
                kbM2 = Keyboard.GetState();
            }


            if (menuState == 3)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && !(kbM3.IsKeyDown(Keys.Right)))
                {
                    SelectorM3X++;
                    if (SelectorM3X > 2)
                        SelectorM3X = 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left) && !(kbM3.IsKeyDown(Keys.Left)))
                {
                    SelectorM3X--;
                    if (SelectorM3X < 1)
                        SelectorM3X = 2;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && !(kbM3.IsKeyDown(Keys.Up)))
                {
                    SelectorM3Y--;
                    if (SelectorM3Y < 1)
                        SelectorM3Y = 3;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && !(kbM3.IsKeyDown(Keys.Down)))
                {
                    SelectorM3Y++;
                    if (SelectorM3Y > 3)
                        SelectorM3Y = 1;
                }

                //Seleccionar mapa y comensar juego----------------------------------------//
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !(kbM3.IsKeyDown(Keys.E)))
                {
                    StageX = SelectorM3X;
                    StageY = SelectorM3Y;
                    SeleccionarStage = true;

                    if (SelectorM3X == 1 && SelectorM3Y == 1)
                        BanderaEscenarios = 1;

                    if (SelectorM3X == 2 && SelectorM3Y == 1)
                        BanderaEscenarios = 2;

                    if (SelectorM3X == 1 && SelectorM3Y == 2)
                        BanderaEscenarios = 3;

                    if (SelectorM3X == 2 && SelectorM3Y == 2)
                        BanderaEscenarios = 4;

                    if (SelectorM3X == 1 && SelectorM3Y == 3)
                        BanderaEscenarios = 5;

                    if (SelectorM3X == 2 && SelectorM3Y == 3)
                        BanderaEscenarios = -1;
                }

                if (SeleccionarStage == true && BanderaEscenarios == -1)
                {
                    RND = EcenarioRND.Next(1, 6);
                    BanderaEscenarios = RND;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM3.IsKeyDown(Keys.Enter)) && SeleccionarStage == true)
                {
                    menuState = 4;
                }
                //----------------------------------------Seleccionar mapa y comensar juego//
                if (Keyboard.GetState().IsKeyDown(Keys.Q) && !(kbM3.IsKeyDown(Keys.Q)))
                {
                    menuState = 2;

                    SelectorM3X = 1;
                    SelectorM3Y = 1;
                    SeleccionarStage = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.C) && !(kbM3.IsKeyDown(Keys.C)))
                {
                    SelectorM3X = 1;
                    SelectorM3Y = 1;
                    SeleccionarStage = false;
                }

                kbM3 = Keyboard.GetState();
            }

            //Juego en curso ----- Menu 4----------------------------------------------------------//
            if (menuState == 5)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && !(kbM5.IsKeyDown(Keys.Up)))
                {
                    SelectorM5--;
                    if (SelectorM5 < 1)
                    {
                        SelectorM5 = 3;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down) && !(kbM5.IsKeyDown(Keys.Down)))
                {
                    SelectorM5++;
                    if (SelectorM5 > 3)
                    {
                        SelectorM5 = 1;
                    }
                }


                if (SelectorM5 == 1 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM5.IsKeyDown(Keys.Enter)))
                    menuState = 4;

                if (SelectorM5 == 2 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM5.IsKeyDown(Keys.Enter)))
                {
                    TiempoUlti = 0;
                    TiempoDash = 0;
                    DashAnaya = 0;
                    TiempoTodoPoderos = 0;
                    TiempoStormBreaker = 0;
                    TiempoInvicible = 0;
                    ChasquidoCz = false;
                    CastruHab2 = 0;
                    TiempoCafeina = 0;
                    SpownQz = 0;
                    SpownAn = 0;
                    SpownZa = 0;
                    SpownGn = 0;
                    SpownCz = 0;
                    SpownCa = 0;
                    QzTiempo1 = 1;
                    QzTiempo2 = 10;
                    QzTiempo3 = 0;
                    AnTiempo1 = 1;
                    AnTiempo2 = 10;
                    AnTiempo3 = 0;
                    ZaTiempo1 = 1;
                    ZaTiempo2 = 10;
                    ZaTiempo3 = 0;
                    GnTiempo1 = 1;
                    GnTiempo2 = 10;
                    GnTiempo3 = 0;
                    CzTiempo1 = 1;
                    CzTiempo2 = 10;
                    CzTiempo3 = 0;
                    CaTiempo1 = 1;
                    CaTiempo2 = 10; 
                    CaTiempo3 = 0;
                    GameOver = false;
                    Ganador = 0;
                    pos_vida1 = new Vector2(834, 41);
                    pos_vida2 = new Vector2(28, 41);

                    menuState = 4;
                }

                if (SelectorM5 == 3 && Keyboard.GetState().IsKeyDown(Keys.Enter) && !(kbM5.IsKeyDown(Keys.Enter)))
                {
                    menuState = 1;

                    SeleccionarP1 = false;
                    SeleccionarP2 = false;
                    Player1 = 0;
                    Player2 = 0;
                    SelectorM2 = 1;
                    SelectorM3X = 1;
                    SelectorM3Y = 1;
                    SeleccionarStage = false;
                    TiempoUlti = 0;
                    TiempoDash = 0;
                    DashAnaya = 0;
                    TiempoTodoPoderos = 0;
                    TiempoStormBreaker = 0;
                    TiempoInvicible = 0;
                    ChasquidoCz = false;
                    CastruHab2 = 0;
                    TiempoCafeina = 0;
                    SpownQz = 0;
                    SpownAn = 0;
                    SpownZa = 0;
                    SpownGn = 0;
                    SpownCz = 0;
                    SpownCa = 0;
                    QzTiempo1 = 1;
                    QzTiempo2 = 10;
                    QzTiempo3 = 0;
                    AnTiempo1 = 1;
                    AnTiempo2 = 10;
                    AnTiempo3 = 0;
                    ZaTiempo1 = 1;
                    ZaTiempo2 = 10;
                    ZaTiempo3 = 0;
                    GnTiempo1 = 1;
                    GnTiempo2 = 10;
                    GnTiempo3 = 0;
                    CzTiempo1 = 1;
                    CzTiempo2 = 10;
                    CzTiempo3 = 0;
                    CaTiempo1 = 1;
                    CaTiempo2 = 10;
                    CaTiempo3 = 0;
                    GameOver = false;
                    Ganador = 0;
                    pos_vida1 = new Vector2(834, 41);
                    pos_vida2 = new Vector2(28, 41);
                }

                kbM5 = Keyboard.GetState();
            }
            //----------------------------------------------------------Juego en curso ----- Menu 4//


            //--------------------------------------------------------------------------------------------------//
            //---------------------------------------Cargamos el juego------------------------------------------//
            //--------------------------------------------------------------------------------------------------//
            if (menuState == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !(kb1.IsKeyDown(Keys.Escape)))
                    menuState = 5;

                kb1 = Keyboard.GetState();
                //Cargamos la HitBox de todos los personajes---------------------------------------------------//
                BQuiroz = new BoundingBox(new Vector3(PQuiroz.X + 40, PQuiroz.Y + 36, 0), new Vector3(PQuiroz.X + TQuiroz.Width - 40, PQuiroz.Y + TQuiroz.Height, 0));
                BAnaya = new BoundingBox(new Vector3(PAnaya.X + 20, PAnaya.Y + 36, 0), new Vector3(PAnaya.X + TAnaya.Width - 20, PAnaya.Y + TAnaya.Height, 0));
                BZama = new BoundingBox(new Vector3(PZama.X + 40, PZama.Y + 36, 0), new Vector3(PZama.X + TZama.Width - 40, PZama.Y + TZama.Height, 0));
                /*Gancho de Zamarripa*/BGancho = new BoundingBox(new Vector3(pos_Gancho.X, pos_Gancho.Y, 0), new Vector3(pos_Gancho.X + GanchoDer.Width, pos_Gancho.Y + GanchoDer.Height, 0));
                BGuillen = new BoundingBox(new Vector3(PGuillen.X, PGuillen.Y + 36, 0), new Vector3(PGuillen.X + TGuillen.Width, PGuillen.Y + TGuillen.Height, 0));
                /*Reloj de Guillen*/BReloj = new BoundingBox(new Vector3(pos_reloj.X, pos_reloj.Y, 0), new Vector3(pos_reloj.X + Reloj.Width, pos_reloj.Y + Reloj.Height, 0));
                BCastru = new BoundingBox(new Vector3(PCastru.X, PCastru.Y + 36, 0), new Vector3(PCastru.X + TCastru.Width, PCastru.Y + TCastru.Height, 0));
                /*Grano de cafe explisivo*/BGranoCafe = new BoundingBox(new Vector3(pos_GranoCafe.X, pos_GranoCafe.Y, 0), new Vector3(pos_GranoCafe.X + GranoCafe.Width, pos_GranoCafe.Y + GranoCafe.Height, 0));
                BCanez = new BoundingBox(new Vector3(PCanez.X, PCanez.Y + 36, 0), new Vector3(PCanez.X + TCanez.Width, PCanez.Y + TCanez.Height, 0));
                //---------------------------------------------------Cargamos la HitBox de todos los personajes//
                //Escenario a cargar------------------------------//
                if (BanderaEscenarios == 1)
                {
                    PlataformaGameTime = Content.Load<Texture2D>("img/Escenarios/PlataformaM1");
                    Pos_PlataformaGameTime = new Vector2(16, 588);
                    BPlataformaGameTime = new BoundingBox(new Vector3(Pos_PlataformaGameTime.X, Pos_PlataformaGameTime.Y, 0),
                        new Vector3(Pos_PlataformaGameTime.X + PlataformaGameTime.Width, Pos_PlataformaGameTime.Y, 0));
                    escenario1.UpDate(gameTime);
                }

                if (BanderaEscenarios == 2)
                {
                    PlataformaGameTime = Content.Load<Texture2D>("img/Escenarios/PlataformaM2");
                    Pos_PlataformaGameTime = new Vector2(40, 623);
                    BPlataformaGameTime = new BoundingBox(new Vector3(Pos_PlataformaGameTime.X, Pos_PlataformaGameTime.Y, 0),
                        new Vector3(Pos_PlataformaGameTime.X + PlataformaGameTime.Width, Pos_PlataformaGameTime.Y, 0));
                    escenario2.UpDate(gameTime);
                }

                if (BanderaEscenarios == 3)
                {
                    PlataformaGameTime = Content.Load<Texture2D>("img/Escenarios/PlataformaM3");
                    Pos_PlataformaGameTime = new Vector2(77, 630);
                    BPlataformaGameTime = new BoundingBox(new Vector3(Pos_PlataformaGameTime.X, Pos_PlataformaGameTime.Y, 0),
                        new Vector3(Pos_PlataformaGameTime.X + PlataformaGameTime.Width, Pos_PlataformaGameTime.Y, 0));
                    escenario3.UpDate(gameTime);
                }

                if (BanderaEscenarios == 4)
                {
                    PlataformaGameTime = Content.Load<Texture2D>("img/Escenarios/PlataformaM4");
                    Pos_PlataformaGameTime = new Vector2(27, 583);
                    BPlataformaGameTime = new BoundingBox(new Vector3(Pos_PlataformaGameTime.X, Pos_PlataformaGameTime.Y, 0),
                        new Vector3(Pos_PlataformaGameTime.X + PlataformaGameTime.Width, Pos_PlataformaGameTime.Y, 0));
                    escenario4.UpDate(gameTime);
                }

                if (BanderaEscenarios == 5)
                {
                    PlataformaGameTime = Content.Load<Texture2D>("img/Escenarios/PlataformaM5");
                    Pos_PlataformaGameTime = new Vector2(109, 573);
                    BPlataformaGameTime = new BoundingBox(new Vector3(Pos_PlataformaGameTime.X, Pos_PlataformaGameTime.Y, 0),
                        new Vector3(Pos_PlataformaGameTime.X + PlataformaGameTime.Width, Pos_PlataformaGameTime.Y, 0));
                    escenario5.UpDate(gameTime);
                }
                //------------------------------Escenario a cargar//

                if (VidaPlayer1 <= 0 && VidaPlayer2 > 0)
                {
                    menuState = 6;
                    Ganador = 2;
                }
                if (VidaPlayer2 <= 0 && VidaPlayer1 > 0)
                {
                    menuState = 6;
                    Ganador = 1;
                }

                if (GameOver == true)
                {
                    if (tiempo % 1000 == 0)
                    {
                        timeWin++;
                        if (timeWin > 3)
                        {
                            menuState = 1;

                            SeleccionarP1 = false;
                            SeleccionarP2 = false;
                            Player1 = 0;
                            Player2 = 0;
                            SelectorM2 = 1;
                            SelectorM3X = 1;
                            SelectorM3Y = 1;
                            SeleccionarStage = false;
                            TiempoUlti = 0;
                            TiempoDash = 0;
                            DashAnaya = 0;
                            TiempoTodoPoderos = 0;
                            TiempoStormBreaker = 0;
                            TiempoInvicible = 0;
                            ChasquidoCz = false;
                            CastruHab2 = 0;
                            TiempoCafeina = 0;
                            SpownQz = 0;
                            SpownAn = 0;
                            SpownZa = 0;
                            SpownGn = 0;
                            SpownCz = 0;
                            SpownCa = 0;
                            QzTiempo1 = 1;
                            QzTiempo2 = 10;
                            QzTiempo3 = 0;
                            AnTiempo1 = 1;
                            AnTiempo2 = 10;
                            AnTiempo3 = 0;
                            ZaTiempo1 = 1;
                            ZaTiempo2 = 10;
                            ZaTiempo3 = 0;
                            GnTiempo1 = 1;
                            GnTiempo2 = 10;
                            GnTiempo3 = 0;
                            CzTiempo1 = 1;
                            CzTiempo2 = 10;
                            CzTiempo3 = 0;
                            CaTiempo1 = 1;
                            CaTiempo2 = 10;
                            CaTiempo3 = 0;
                            GameOver = false;
                            Ganador = 0;
                            pos_vida1 = new Vector2(834, 41);
                            pos_vida2 = new Vector2(28, 41);
                        }
                    }
                }
                //Player 1----------------------------------------------------------------------//
                if (Player1 == 1)
                {
                    BJugadorGameTime1 = BQuiroz;
                    pos_JugadorGameTime1 = PQuiroz;
                    JugadorGameTime1 = TQuiroz;

                    Quiroz(gameTime);
                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBQz.IsKeyDown(Keys.P)))
                    {
                        if (BQuiroz.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBQz = Keyboard.GetState();
                    //Contador de tiempo del Disparo
                    if (tiempo % 1000 == 0)
                    {
                        QzTiempo1++;
                        if (QzTiempo1 > 1)
                            QzTiempo1 = 1;

                        QzTiempo2++;
                        if (QzTiempo2 > 10)
                            QzTiempo2 = 10;

                        QzTiempo3++;
                        if (QzTiempo3 > 45)
                            QzTiempo3 = 45;
                    }
                    //Verificar dispario Disparo
                    if (QzTiempo1 == 1)
                    {
                        QzDisparo_Der(gameTime);
                        QzDisparo_Izq(gameTime);
                    }

                    if (QzTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.I) && !(kbM5.IsKeyDown(Keys.I)))
                        {
                            Heal = true;
                            QzTiempo2 = 0;
                        }

                        kbM5 = Keyboard.GetState();

                        if (Heal == true)
                        {
                            VidaPlayer1 += 100;
                            pos_vida1.X -= 100;
                            if (VidaPlayer1 > 500)
                            {
                                VidaPlayer1 = 500;
                                pos_vida1 = new Vector2(834, 41);
                            }
                            Heal = false;
                        }
                    }


                    if (QzTiempo3 == 45)
                    {
                        QuirozUltiIzq(gameTime);
                        QuirozUltiDer(gameTime);
                    }

                    //Si se cae de la plataforma------------------------
                    if (PQuiroz.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PQuiroz = new Vector2(650, -350);
                    }
                }





                if (Player1 == 2)
                {
                    BJugadorGameTime1 = BAnaya;
                    pos_JugadorGameTime1 = PAnaya;
                    JugadorGameTime1 = TAnaya;

                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBAn.IsKeyDown(Keys.P)))
                    {
                        if (BAnaya.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBAn = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        AnTiempo1++;
                        if (AnTiempo1 > 1)
                            AnTiempo1 = 1;

                        AnTiempo2++;
                        if (AnTiempo2 > 10)
                            AnTiempo2 = 10;

                        AnTiempo3++;
                        if (AnTiempo3 > 45)
                            AnTiempo3 = 45;
                    }

                    Anaya(gameTime);
                    if (AnTiempo1 == 1)
                    {
                        AnDisparo_Der(gameTime);
                        AnDisparo_Izq(gameTime);
                    }

                    if (AnTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.I) && ActivarDash == false)
                        {
                            DashAnaya = 45;
                            ActivarDash = true;
                        }
                        if (ActivarDash == true)
                        {
                            if (BAnaya.Intersects(BJugadorGameTime2))
                            {
                                VidaPlayer2 -= 20;
                                pos_vida2.X -= 20;
                            }
                            if (tiempo % 200 == 0)
                                TiempoDash++;

                            if (TiempoDash > 1)
                            {
                                TiempoDash = 0;
                                ActivarDash = false;
                                DashAnaya = 0;
                                AnTiempo2 = 0;
                            }
                        }
                    }

                    if (AnTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U) && TodoPoderos == false)
                        {
                            TodoPoderos = true;
                            soundBank.PlayCue("Ulti_Anaya");
                        }

                        if (TodoPoderos == true)
                        {
                            rnd_rayo = new Random();
                            if (tiempo % 1000 == 0)
                                TiempoTodoPoderos++;

                            if (tiempo % 200 == 0)
                            {
                                VidaPlayer1 = 500;
                                pos_vida1 = new Vector2(834, 41);
                            }

                            if (tiempo % 500 == 0)
                            {
                                pos_randomRayo = rnd_rayo.Next(0, 400);
                                pos_Rayos.X = pos_randomRayo;
                            }

                            if (tiempo % 1000 == 0)
                            {
                                soundBank.PlayCue("Rayo Efecto");
                                VidaPlayer2 -= 20;
                                pos_vida2.X -= 20;
                            }

                            if (TiempoTodoPoderos > 8)
                            {
                                TodoPoderos = false;
                                TiempoTodoPoderos = 0;
                                AnTiempo3 = 0;
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PAnaya.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PAnaya = new Vector2(650, -350);
                    }
                }





                if (Player1 == 3)
                {
                    BJugadorGameTime1 = BZama;
                    pos_JugadorGameTime1 = PZama;
                    JugadorGameTime1 = TZama;

                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBZa.IsKeyDown(Keys.P)))
                    {
                        if (BZama.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBZa = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        ZaTiempo1++;
                        if (ZaTiempo1 > 1)
                            ZaTiempo1 = 1;

                        ZaTiempo2++;
                        if (ZaTiempo2 > 10)
                            ZaTiempo2 = 10;

                        ZaTiempo3++;
                        if (ZaTiempo3 > 45)
                            ZaTiempo3 = 45;
                    }

                    Zamarripa(gameTime);

                    if (ZaTiempo1 == 1)
                    {
                        ZaDisparoDer(gameTime);
                        ZaDisparoIzq(gameTime);
                    }
                    if (ZaTiempo2 == 10)
                    {
                        ZamaGanchoDer(gameTime);
                        ZamaGanchoIzq(gameTime);
                    }
                    if (ZaTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U) && StormBreaker == false)
                            StormBreaker = true;

                        if (StormBreaker == true)
                        {
                            if (tiempo % 1000 == 0)
                                TiempoStormBreaker++;

                            if (TiempoStormBreaker == 20)
                            {
                                StormBreaker = false;
                                TiempoStormBreaker = 0;
                                ZaTiempo3 = 0;
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PZama.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PZama = new Vector2(650, -350);
                    }
                }





                if (Player1 == 4)
                {
                    BJugadorGameTime1 = BGuillen;
                    pos_JugadorGameTime1 = PGuillen;
                    JugadorGameTime1 = TGuillen;

                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBGn.IsKeyDown(Keys.P)))
                    {
                        if (BGuillen.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBGn = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        GnTiempo1++;
                        if (GnTiempo1 > 1)
                            GnTiempo1 = 1;

                        GnTiempo2++;
                        if (GnTiempo2 > 10)
                            GnTiempo2 = 10;

                        GnTiempo3++;
                        if (GnTiempo3 > 45)
                            GnTiempo3 = 45;
                    }
                    Guillen(gameTime);

                    if (GnTiempo1 == 1)
                    {
                        GnDisparoDer(gameTime);
                        GnDisparoIzq(gameTime);
                    }

                    if (GnTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.I) && Invisivilidad == false)
                            Invisivilidad = true;

                        if (Invisivilidad == true)
                        {
                            if (tiempo % 1000 == 0)
                                TiempoInvicible++;

                            if (TiempoInvicible == 8)
                            {
                                Invisivilidad = false;
                                TiempoInvicible = 0;
                                GnTiempo2 = 0;
                            }
                        }
                    }

                    if (GnTiempo3 == 45)
                    {
                        if (Player1 == 4)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.U))
                            {
                                LanzarReloj = true;
                                NoCaminarGn = true;
                                banderaGn = 22;
                            }
                        }

                        if (LanzarReloj == true)
                        {
                            if (DireccionGn == true)
                            {
                                pos_reloj.X += 8;
                                if (BReloj.Intersects(BJugadorGameTime2))
                                {
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(pos_JugadorGameTime2.X + 50, pos_JugadorGameTime2.Y);
                                    if (tiempo % 1000 == 0)
                                    {
                                        TiempoParaReaccion++;
                                        if (TiempoParaReaccion > 3)
                                            TiempoParaReaccion = 3;
                                    }
                                }
                                else if (pos_reloj.X >= 1400 || pos_reloj.X <= -100)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                            if (DireccionGn == false)
                            {
                                pos_reloj.X -= 8;
                                if (BReloj.Intersects(BJugadorGameTime2))
                                {
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(pos_JugadorGameTime2.X + 50, pos_JugadorGameTime2.Y);

                                    if (tiempo % 1000 == 0)
                                    {
                                        TiempoParaReaccion++;
                                        if (TiempoParaReaccion > 3)
                                            TiempoParaReaccion = 3;
                                    }
                                }
                                else if (pos_reloj.X >= 1400 || pos_reloj.X <= -100)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                        }
                        if (TiempoParaReaccion == 2 && BReloj.Intersects(BJugadorGameTime2))
                            Inmovil = true;

                        if (Inmovil == true)
                        {
                            if (tiempo % 1000 == 0)
                            {
                                VidaPlayer2 -= 15;
                                pos_vida2.X -= 15;

                                TiempoInmovil++;
                                if(TiempoInmovil == 8)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PGuillen.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PGuillen = new Vector2(650, -350);
                    }
                }





                if (Player1 == 5)
                {
                    BJugadorGameTime1 = BCanez;
                    pos_JugadorGameTime1 = PCanez;
                    JugadorGameTime1 = TCanez;

                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBCz.IsKeyDown(Keys.P)))
                    {
                        if (BCanez.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBCz = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        CzTiempo1++;
                        if (CzTiempo1 > 1)
                            CzTiempo1 = 1;

                        CzTiempo2++;
                        if(CzTiempo2 > 10)
                            CzTiempo2 = 10;

                        CzTiempo3++;
                        if (CzTiempo3 > 45)
                            CzTiempo3 = 45;
                    }
                    Canez(gameTime);

                    if (CzTiempo1 == 1)
                    {
                        CzDisparo_Der(gameTime);
                        CzDisparo_Izq(gameTime);
                    }
                    if (CzTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.I) && !(kbM3.IsKeyDown(Keys.I)))
                        {
                            HealCz = true;
                            CzTiempo2 = 0;
                        }

                        kbM3 = Keyboard.GetState();

                        if (HealCz == true)
                        {
                            VidaPlayer1 += 100;
                            pos_vida1.X -= 100;
                            if (VidaPlayer1 > 500)
                            {
                                VidaPlayer1 = 500;
                                pos_vida1 = new Vector2(834, 41);
                            }
                            HealCz = false;
                        }
                    }

                    if (CzTiempo3 == 45)
                        ChasquidoCanez(gameTime);
                    //Si se cae de la platafoma------------------------
                    if (PCanez.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PCanez = new Vector2(650, -350);
                    }
                }





                if (Player1 == 6)
                {
                    BJugadorGameTime1 = BCastru;
                    pos_JugadorGameTime1 = PCastru;
                    JugadorGameTime1 = TCastru;

                    if (Keyboard.GetState().IsKeyDown(Keys.P) && !(KBCa.IsKeyDown(Keys.P)))
                    {
                        if (BCastru.Intersects(BJugadorGameTime2))
                        {
                            VidaPlayer2 -= 3;
                            pos_vida2.X -= 3;
                        }
                    }
                    KBCa = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        CaTiempo1++;
                        if (CaTiempo1 > 1)
                            CaTiempo1 = 1;

                        CaTiempo2++;
                        if(CaTiempo2 >10)
                            CaTiempo2 = 10;

                        CaTiempo3++;
                        if (CaTiempo3 > 45)
                            CaTiempo3 = 45;
                    }
                    Castruita(gameTime);
                    if (CaTiempo1 == 1)
                    {
                        CaDisparoDer(gameTime);
                        CaDisparoIzq(gameTime);
                    }

                    if (CaTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.I) && ActivarCafeina == false)
                        {
                            CastruHab2 = 10;
                            ActivarCafeina = true;
                        }
                    }
                    if (ActivarCafeina == true)
                    {
                        if (tiempo % 1000 == 0)
                            TiempoCafeina++;

                        if (TiempoCafeina > 5)
                        {
                            TiempoCafeina = 0;
                            ActivarCafeina = false;
                            CastruHab2 = 0;
                            CaTiempo2 = 0;
                        }
                    }

                    if (CaTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U))
                        {
                            LanzarGrano = true;
                            NoCaminarCa = true;
                            banderaCa = 23;
                        }

                        if (LanzarGrano == true)
                        {
                            if (DireccionCa == true)
                            {
                                pos_GranoCafe.X += 10;
                                pos_GranoCafe.Y += 5;
                                if (BGranoCafe.Intersects(BPlataformaGameTime) || BGranoCafe.Intersects(BJugadorGameTime2))
                                {
                                    NoCaminarCa = false;
                                    Explotar = true;
                                }
                                else if (pos_GranoCafe.X <= -100 || pos_GranoCafe.X >= 1400)
                                {
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                }

                                if (Explotar == true && BGranoCafe.Intersects(BJugadorGameTime2))
                                {
                                    VidaPlayer2 -= 300;
                                    pos_vida2.X -= 300;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                                else if (Explotar == true && BGranoCafe.Intersects(BPlataformaGameTime))
                                {
                                    VidaPlayer2 -= 180;
                                    pos_vida2.X -= 180;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                            }
                            if (DireccionCa == false)
                            {
                                pos_GranoCafe.X -= 10;
                                pos_GranoCafe.Y += 5;
                                if (BGranoCafe.Intersects(BPlataformaGameTime) || BGranoCafe.Intersects(BJugadorGameTime2))
                                {
                                    NoCaminarCa = false;
                                    Explotar = true;
                                }
                                else if (pos_GranoCafe.X <= -100 || pos_GranoCafe.X >= 1400)
                                {
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                }

                                if (Explotar == true && BGranoCafe.Intersects(BJugadorGameTime2))
                                {
                                    VidaPlayer2 -= 300;
                                    pos_vida2.X -= 300;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                                else if (Explotar == true && BGranoCafe.Intersects(BPlataformaGameTime))
                                {
                                    VidaPlayer2 -= 180;
                                    pos_vida2.X -= 180;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PCastru.Y >= 1000)
                    {
                        VidaPlayer1 -= 100;
                        pos_vida1.X += 100;
                        PCastru = new Vector2(650, -350);
                    }
                }

                //----------------------------------------------------------------------Player 1//

                //Player 2----------------------------------------------------------------------//
                if (Player2 == 1)
                {
                    BJugadorGameTime2 = BQuiroz;
                    pos_JugadorGameTime2 = PQuiroz;
                    JugadorGameTime2 = TQuiroz;
                    Quiroz(gameTime);

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBQz.IsKeyDown(Keys.E)))
                    {
                        if (BQuiroz.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBQz = Keyboard.GetState();
                    //Contador de tiempo del Disparo
                    if (tiempo % 1000 == 0)
                    {
                        QzTiempo1++;
                        if (QzTiempo1 > 1)
                            QzTiempo1 = 1;

                        QzTiempo2++;
                        if (QzTiempo2 > 10)
                            QzTiempo2 = 10;

                        QzTiempo3++;
                        if (QzTiempo3 > 45)
                            QzTiempo3 = 45;
                    }
                    //Verificar dispario Disparo
                    if (QzTiempo1 == 1)
                    {
                        QzDisparo_Der(gameTime);
                        QzDisparo_Izq(gameTime);
                    }

                    if (QzTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.T) && !(kbM5.IsKeyDown(Keys.T)))
                        {
                            Heal = true;
                            QzTiempo2 = 0;
                        }

                        kbM5 = Keyboard.GetState();

                        if (Heal == true)
                        {
                            VidaPlayer2 += 100;
                            pos_vida2.X += 100;
                            if (VidaPlayer2 > 500)
                            {
                                VidaPlayer2 = 500;
                                pos_vida2 = new Vector2(28, 41);
                            }
                            Heal = false;
                        }
                    }


                    if (QzTiempo3 == 45)
                    {
                        QuirozUltiIzq(gameTime);
                        QuirozUltiDer(gameTime);
                    }
                    //Si se cae de la plataforma------------------------
                    if (PQuiroz.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PQuiroz = new Vector2(650, -350);
                    }
                }





                if (Player2 == 2)
                {
                    BJugadorGameTime2 = BAnaya;
                    pos_JugadorGameTime2 = PAnaya;
                    JugadorGameTime2 = TAnaya;

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBAn.IsKeyDown(Keys.E)))
                    {
                        if (BAnaya.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBAn = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        AnTiempo1++;
                        if (AnTiempo1 > 1)
                            AnTiempo1 = 1;

                        AnTiempo2++;
                        if (AnTiempo2 > 10)
                            AnTiempo2 = 10;

                        AnTiempo3++;
                        if (AnTiempo3 > 45)
                            AnTiempo3 = 45;
                    }

                    Anaya(gameTime);
                    if (AnTiempo1 == 1)
                    {
                        AnDisparo_Der(gameTime);
                        AnDisparo_Izq(gameTime);
                    }
                    if (AnTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.T) && ActivarDash == false)
                        {
                            DashAnaya = 45;
                            ActivarDash = true;
                        }
                        if(ActivarDash == true)
                        {
                            if (BAnaya.Intersects(BJugadorGameTime1))
                            {
                                VidaPlayer1 -= 20;
                                pos_vida1.X += 20;
                            }

                            if (tiempo % 200 == 0)
                                TiempoDash++;

                            if (TiempoDash > 1)
                            {
                                TiempoDash = 0;
                                ActivarDash = false;
                                DashAnaya = 0;
                                AnTiempo2 = 0;
                            }
                        }
                    }

                    if (AnTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y) && TodoPoderos == false)
                        {
                            TodoPoderos = true;
                            soundBank.PlayCue("Ulti_Anaya");
                        }

                        if (TodoPoderos == true)
                        {
                            rnd_rayo = new Random();
                            if (tiempo % 1000 == 0)
                                TiempoTodoPoderos++;

                            if (tiempo % 200 == 0)
                            {
                                VidaPlayer2 = 500;
                                pos_vida2 = new Vector2(28, 41);
                            }

                            if (tiempo % 500 == 0)
                            {
                                pos_randomRayo = rnd_rayo.Next(0, 400);
                                pos_Rayos.X = pos_randomRayo;
                            }

                            if (tiempo % 1000 == 0)
                            {
                                soundBank.PlayCue("Rayo Efecto");
                                VidaPlayer1 -= 20;
                                pos_vida1.X += 20;
                            }

                            if (TiempoTodoPoderos > 8)
                            {
                                TodoPoderos = false;
                                TiempoTodoPoderos = 0;
                                AnTiempo3 = 0;
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PAnaya.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PAnaya = new Vector2(650, -350);
                    }
                }





                if (Player2 == 3)
                {
                    BJugadorGameTime2 = BZama;
                    pos_JugadorGameTime2 = PZama;
                    JugadorGameTime2 = TZama;

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBZa.IsKeyDown(Keys.E)))
                    {
                        if (BZama.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBZa = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        ZaTiempo1++;
                        if (ZaTiempo1 > 1)
                            ZaTiempo1 = 1;

                        ZaTiempo2++;
                        if (ZaTiempo2 > 10)
                            ZaTiempo2 = 10;

                        ZaTiempo3++;
                        if (ZaTiempo3 > 45)
                            ZaTiempo3 = 45;
                    }

                    Zamarripa(gameTime);

                    if (ZaTiempo1 == 1)
                    {
                        ZaDisparoDer(gameTime);
                        ZaDisparoIzq(gameTime);
                    }
                    if (ZaTiempo2 == 10)
                    {
                        ZamaGanchoDer(gameTime);
                        ZamaGanchoIzq(gameTime);
                    }
                    if (ZaTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y) && StormBreaker == false)
                            StormBreaker = true;

                        if (StormBreaker == true)
                        {
                            if (tiempo % 1000 == 0)
                                TiempoStormBreaker++;

                            if (TiempoStormBreaker == 20)
                            {
                                StormBreaker = false;
                                TiempoStormBreaker = 0;
                                ZaTiempo3 = 0;
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PZama.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PZama = new Vector2(650, -350);
                    }
                }





                if (Player2 == 4)
                {
                    BJugadorGameTime2 = BGuillen;
                    pos_JugadorGameTime2 = PGuillen;
                    JugadorGameTime2 = TGuillen;

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBGn.IsKeyDown(Keys.E)))
                    {
                        if (BGuillen.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBGn = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        GnTiempo1++;
                        if (GnTiempo1 > 1)
                            GnTiempo1 = 1;

                        GnTiempo2++;
                        if (GnTiempo2 > 10)
                            GnTiempo2 = 10;

                        GnTiempo3++;
                        if (GnTiempo3 > 45)
                            GnTiempo3 = 45;
                    }
                    Guillen(gameTime);

                    if (GnTiempo1 == 1)
                    {
                        GnDisparoDer(gameTime);
                        GnDisparoIzq(gameTime);
                    }

                    if (GnTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.T) && Invisivilidad == false)
                            Invisivilidad = true;

                        if (Invisivilidad == true)
                        {
                            if (tiempo % 1000 == 0)
                                TiempoInvicible++;

                            if (TiempoInvicible == 8)
                            {
                                Invisivilidad = false;
                                TiempoInvicible = 0;
                                GnTiempo2 = 0;
                            }
                        }
                    }

                    if (GnTiempo3 == 45)
                    {
                        if (Player2 == 4)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Y))
                            {
                                LanzarReloj = true;
                                NoCaminarGn = true;
                                banderaGn = 22;
                            }
                        }

                        if (LanzarReloj == true)
                        {
                            if (DireccionGn == true)
                            {
                                pos_reloj.X += 8;
                                if (BReloj.Intersects(BJugadorGameTime1))
                                {
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(pos_JugadorGameTime1.X + 50, pos_JugadorGameTime1.Y);
                                    if (tiempo % 1000 == 0)
                                    {
                                        TiempoParaReaccion++;
                                        if (TiempoParaReaccion > 3)
                                            TiempoParaReaccion = 3;
                                    }
                                }
                                else if (pos_reloj.X >= 1400 || pos_reloj.X <= -100)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                            if (DireccionGn == false)
                            {
                                pos_reloj.X -= 8;
                                if (BReloj.Intersects(BJugadorGameTime1))
                                {
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(pos_JugadorGameTime1.X + 50, pos_JugadorGameTime1.Y);

                                    if (tiempo % 1000 == 0)
                                    {
                                        TiempoParaReaccion++;
                                        if (TiempoParaReaccion > 3)
                                            TiempoParaReaccion = 3;
                                    }
                                }
                                else if (pos_reloj.X >= 1400 || pos_reloj.X <= -100)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    NoCaminarGn = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                        }
                        if (TiempoParaReaccion == 2 && BReloj.Intersects(BJugadorGameTime1))
                            Inmovil = true;

                        if (Inmovil == true)
                        {
                            if (tiempo % 1000 == 0)
                            {
                                VidaPlayer1 -= 15;
                                pos_vida1.X += 15;

                                TiempoInmovil++;
                                if (TiempoInmovil == 8)
                                {
                                    Inmovil = false;
                                    LanzarReloj = false;
                                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                                    GnTiempo3 = 0;
                                    TiempoInmovil = 0;
                                    TiempoParaReaccion = 0;
                                }
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PGuillen.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PGuillen = new Vector2(650, -350);
                    }
                }





                if (Player2 == 5)
                {
                    BJugadorGameTime2 = BCanez;
                    pos_JugadorGameTime2 = PCanez;
                    JugadorGameTime2 = TCanez;

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBCz.IsKeyDown(Keys.E)))
                    {
                        if (BCanez.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBCz = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        CzTiempo1++;
                        if (CzTiempo1 > 1)
                            CzTiempo1 = 1;

                        CzTiempo2++;
                        if (CzTiempo2 > 10)
                            CzTiempo2 = 10;

                        CzTiempo3++;
                        if (CzTiempo3 > 45)
                            CzTiempo3 = 45;
                    }
                    Canez(gameTime);
                    if (CzTiempo1 == 1)
                    {
                        CzDisparo_Der(gameTime);
                        CzDisparo_Izq(gameTime);
                    }
                    if (CzTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.T) && !(kbM3.IsKeyDown(Keys.T)))
                        {
                            HealCz = true;
                            CzTiempo2 = 0;
                        }

                        kbM3 = Keyboard.GetState();

                        if (HealCz == true)
                        {
                            VidaPlayer2 += 100;
                            pos_vida2.X += 100;
                            if (VidaPlayer2 > 500)
                            {
                                VidaPlayer2 = 500;
                                pos_vida2 = new Vector2(28, 41);
                            }
                            HealCz = false;
                        }
                    }

                    if (CzTiempo3 == 45)
                        ChasquidoCanez(gameTime);
                    //Si se cae de la plataforma------------------------
                    if (PCanez.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PCanez = new Vector2(650, -350);
                    }
                }





                if (Player2 == 6)
                {
                    BJugadorGameTime2 = BCastru;
                    pos_JugadorGameTime2 = PCastru;
                    JugadorGameTime2 = TCastru;

                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !(KBCa.IsKeyDown(Keys.E)))
                    {
                        if (BCastru.Intersects(BJugadorGameTime1))
                        {
                            VidaPlayer1 -= 3;
                            pos_vida1.X += 3;
                        }
                    }
                    KBCa = Keyboard.GetState();
                    if (tiempo % 1000 == 0)
                    {
                        CaTiempo1++;
                        if (CaTiempo1 > 1)
                            CaTiempo1 = 1;

                        CaTiempo2++;
                        if (CaTiempo2 > 10)
                            CaTiempo2 = 10;

                        CaTiempo3++;
                        if (CaTiempo3 > 45)
                            CaTiempo3 = 45;
                    }
                    Castruita(gameTime);
                    if (CaTiempo1 == 1)
                    {
                        CaDisparoDer(gameTime);
                        CaDisparoIzq(gameTime);
                    }

                    if (CaTiempo2 == 10)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.T) && ActivarCafeina == false)
                        {
                            CastruHab2 = 10;
                            ActivarCafeina = true;
                        }
                    }
                    if (ActivarCafeina == true)
                    {
                        if (tiempo % 1000 == 0)
                            TiempoCafeina++;

                        if (TiempoCafeina > 5)
                        {
                            TiempoCafeina = 0;
                            ActivarCafeina = false;
                            CastruHab2 = 0;
                            CaTiempo2 = 0;
                        }
                    }

                    if (CaTiempo3 == 45)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y))
                        {
                            LanzarGrano = true;
                            NoCaminarCa = true;
                            banderaCa = 23;
                        }

                        if (LanzarGrano == true)
                        {
                            if (DireccionCa == true)
                            {
                                pos_GranoCafe.X += 10;
                                pos_GranoCafe.Y += 5;
                                if (BGranoCafe.Intersects(BPlataformaGameTime) || BGranoCafe.Intersects(BJugadorGameTime1))
                                {
                                    NoCaminarCa = false;
                                    Explotar = true;
                                }
                                else if (pos_GranoCafe.X <= -100 || pos_GranoCafe.X >= 1400)
                                {
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                }

                                if (Explotar == true && BGranoCafe.Intersects(BJugadorGameTime1))
                                {
                                    VidaPlayer1 -= 300;
                                    pos_vida1.X += 300;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                                else if (Explotar == true && BGranoCafe.Intersects(BPlataformaGameTime))
                                {
                                    VidaPlayer1 -= 180;
                                    pos_vida1.X += 180;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                            }
                            if (DireccionCa == false)
                            {
                                pos_GranoCafe.X -= 10;
                                pos_GranoCafe.Y += 5;
                                if (BGranoCafe.Intersects(BPlataformaGameTime) || BGranoCafe.Intersects(BJugadorGameTime1))
                                {
                                    NoCaminarCa = false;
                                    Explotar = true;
                                }
                                else if (pos_GranoCafe.X <= -100 || pos_GranoCafe.X >= 1400)
                                {
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                }

                                if (Explotar == true && BGranoCafe.Intersects(BJugadorGameTime1))
                                {
                                    VidaPlayer1 -= 300;
                                    pos_vida1.X += 300;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                                else if (Explotar == true && BGranoCafe.Intersects(BPlataformaGameTime))
                                {
                                    VidaPlayer1 -= 180;
                                    pos_vida1.X += 180;
                                    Explotar = false;
                                    LanzarGrano = false;
                                    CaTiempo3 = 0;
                                    soundBank.PlayCue("Explocion");
                                }
                            }
                        }
                    }
                    //Si se cae de la plataforma------------------------
                    if (PCastru.Y >= 1000)
                    {
                        VidaPlayer2 -= 100;
                        pos_vida2.X -= 100;
                        PCastru = new Vector2(650, -350);
                    }
                }
                //----------------------------------------------------------------------Player 2//
            }
            //--------------------------------------------------------------------------------------------------//
            //---------------------------------------Cargamos el juego------------------------------------------//
            //--------------------------------------------------------------------------------------------------//
            base.Update(gameTime);
        }









        //CREAMOS LOS MOVIMIENTOS Y AVILIDADES-------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------CREAMOS LOS MOVIMIENTOS Y AVILIDADES//
        void Quiroz(GameTime gameTime)
        {
            if (Player1 == 1 && Inmovil != true)
            {
                if (Player1 == 1 && SpownQz == 0)
                {
                    PQuiroz.X = 1200;
                    DireccionQZ = false;
                    SpownQz++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    DireccionQZ = true;
                    PQuiroz.X += 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaQz++;
                        if (banderaQz > 3)
                            banderaQz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    DireccionQZ = false;
                    PQuiroz.X -= 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaQz++;
                        if (banderaQz > 3)
                            banderaQz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    PQuiroz.Y -= 10;

                    if (DireccionQZ == true)
                        banderaQz = 20;

                    if (DireccionQZ == false)
                        banderaQz = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 1 && Inmovil != true)
            {
                if (Player2 == 1 && SpownQz == 0)
                {
                    PQuiroz.X = 100;
                    DireccionQZ = true;
                    SpownQz++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    DireccionQZ = true;
                    PQuiroz.X += 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaQz++;
                        if (banderaQz > 3)
                            banderaQz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    DireccionQZ = false;
                    PQuiroz.X -= 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaQz++;
                        if (banderaQz > 3)
                            banderaQz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    PQuiroz.Y -= 10;

                    if (DireccionQZ == true)
                        banderaQz = 20;

                    if (DireccionQZ == false)
                        banderaQz = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BQuiroz.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 1)
                {
                    if (DireccionQZ == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaQz = 0;

                    if (DireccionQZ == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaQz = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 1)
                {
                    if (DireccionQZ == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaQz = 0;

                    if (DireccionQZ == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaQz = 0;
                }
                //----------------------------------------Jugador 2//
            }
            //Abilidades de Quiroz 1 y 2--------------------------------------//
            if (Player1 == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaQz = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionQZ == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PQuiroz.X -= 5;

                    if (DireccionQZ == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PQuiroz.X += 5;

                    banderaQz = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.I))
                    banderaQz = 23;
            }

            if (Player2 == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaQz = 21;

                
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionQZ == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PQuiroz.X -= 5;

                    if (DireccionQZ == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PQuiroz.X += 5;

                    banderaQz = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.T))
                    banderaQz = 23;
            }
            //--------------------------------------Abilidades de Quiroz 1 y 2//
            //Si no esta en las plataformas caera al basio
            if (!BQuiroz.Intersects(BPlataformaGameTime))
                caeQZ = true;

            else
            {
                caeQZ = false;
                masaQZ = 5f;
                tiemposueltoQZ = 0;
                timeUPQZ = 0.05f;
            }
            if (caeQZ == true)
            {
                tiemposueltoQZ += timeUPQZ;
                PQuiroz.Y = PQuiroz.Y + (masaQZ * tiemposueltoQZ);
            }



            int contador1QZ;
            for (contador1QZ = 0; contador1QZ < ListaDisparosDerQZ.Count; contador1QZ++)
            {
                if (ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X > 0)
                {
                    disparoDerQZ = ListaDisparosDerQZ[contador1QZ];
                    disparoDerQZ.posDisparoDerQZ = new Vector2(ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X + ListaDisparosDerQZ[contador1QZ].velDiaparoDerQZ, ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.Y);
                    disparoDerQZ.velDiaparoDerQZ += 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosDerQZ[contador1QZ] = disparoDerQZ;



                    if (Player1 == 1)
                    {
                        if (ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X + ListaDisparosDerQZ[contador1QZ].disparoDerQZ.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosDerQZ.RemoveAt(contador1QZ);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X + ListaDisparosDerQZ[contador1QZ].disparoDerQZ.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosDerQZ[contador1QZ].posDisparoDerQZ.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosDerQZ.RemoveAt(contador1QZ);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosDerQZ.RemoveAt(contador1QZ);
                }
            }
            int contador2QZ;
            for (contador2QZ = 0; contador2QZ < ListaDisparosIzqQZ.Count; contador2QZ++)
            {
                if (ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X > 0)
                {
                    disparoIzqQZ = ListaDisparosIzqQZ[contador2QZ];
                    disparoIzqQZ.posDisparoIzqQZ = new Vector2(ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X + ListaDisparosIzqQZ[contador2QZ].velDiaparoIzqQZ, ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.Y);
                    disparoIzqQZ.velDiaparoIzqQZ -= 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosIzqQZ[contador2QZ] = disparoIzqQZ;

                    if (Player1 == 1)
                    {
                        if (ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X + ListaDisparosIzqQZ[contador2QZ].disparoIzqQZ.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosIzqQZ.RemoveAt(contador2QZ);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X + ListaDisparosIzqQZ[contador2QZ].disparoIzqQZ.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width  &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosIzqQZ[contador2QZ].posDisparoIzqQZ.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosIzqQZ.RemoveAt(contador2QZ);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosIzqQZ.RemoveAt(contador2QZ);
                }
            }


            
            //Ulti de Quiroz
            //Disparo Izquierda---------------
            for (int i = 0; i < ListaDisparosUltiIzq.Count; i++)
            {
                if (ListaDisparosUltiIzq[i].posRayoUltiIzq.X > 0)
                {
                    disparoUltiIzq = ListaDisparosUltiIzq[i];
                    disparoUltiIzq.posRayoUltiIzq = new Vector2(ListaDisparosUltiIzq[i].posRayoUltiIzq.X - ListaDisparosUltiIzq[i].velRayoUltiIzq, ListaDisparosUltiIzq[i].posRayoUltiIzq.Y);
                    disparoUltiIzq.rotacionUltiIzq += 0.3f;
                    if (disparoUltiIzq.rotacionUltiIzq == 360)
                        disparoUltiIzq.rotacionUltiIzq = 0;

                    disparoUltiIzq.velRayoUltiIzq += 0.38f;
                    ListaDisparosUltiIzq[i] = disparoUltiIzq;

                    if (Player1 == 1)
                    {
                        if (ListaDisparosUltiIzq[i].posRayoUltiIzq.X + ListaDisparosUltiIzq[i].rayoUltiIzq.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosUltiIzq.RemoveAt(i);
                            VidaPlayer2 --;
                            pos_vida2.X --;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (ListaDisparosUltiIzq[i].posRayoUltiIzq.X + ListaDisparosUltiIzq[i].rayoUltiIzq.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosUltiIzq[i].posRayoUltiIzq.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosUltiIzq.RemoveAt(i);
                            VidaPlayer1 --;
                            pos_vida1.X ++;
                        }
                    }
                }
                else
                {
                    ListaDisparosUltiIzq.RemoveAt(i);
                }
            }
            
            //Disparo Drecha---------------
            for (int i = 0; i < ListaDisparosUltiDer.Count; i++)
            {
                if (ListaDisparosUltiDer[i].posRayoUltiDer.X > 0)
                {
                    disparoUltiDer = ListaDisparosUltiDer[i];
                    disparoUltiDer.posRayoUltiDer = new Vector2(ListaDisparosUltiDer[i].posRayoUltiDer.X + ListaDisparosUltiDer[i].velRayoUltiDer, ListaDisparosUltiDer[i].posRayoUltiDer.Y);
                    disparoUltiDer.rotacionUltiDer += 0.3f;
                    if (disparoUltiDer.rotacionUltiDer == 360)
                        disparoUltiDer.rotacionUltiDer = 0;

                    disparoUltiDer.velRayoUltiDer += 0.38f;
                    ListaDisparosUltiDer[i] = disparoUltiDer;

                    if (Player1 == 1)
                    {
                        if (ListaDisparosUltiDer[i].posRayoUltiDer.X + ListaDisparosUltiDer[i].rayoUltiDer.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosUltiDer.RemoveAt(i);
                            VidaPlayer2 --;
                            pos_vida2.X --;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (ListaDisparosUltiDer[i].posRayoUltiDer.X + ListaDisparosUltiDer[i].rayoUltiDer.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosUltiDer[i].posRayoUltiDer.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosUltiDer.RemoveAt(i);
                            VidaPlayer1 --;
                            pos_vida1.X ++;
                        }
                    }
                }
                else
                {
                    ListaDisparosUltiDer.RemoveAt(i);
                }
            }
        }





        void Anaya(GameTime gameTime)
        {
            if (Player1 == 2 && Inmovil != true)
            {
                if (Player1 == 2 && SpownAn == 0)
                {
                    PAnaya.X = 1200;
                    DireccionAn = false;
                    SpownAn++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    DireccionAn = true;
                    PAnaya.X += 5 + DashAnaya;
                    if (tiempo % 150 == 0)
                    {
                        banderaAn++;
                        if (banderaAn > 4)
                            banderaAn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    DireccionAn = false;
                    PAnaya.X -= 5 + DashAnaya;
                    if (tiempo % 150 == 0)
                    {
                        banderaAn++;
                        if (banderaAn > 4)
                            banderaAn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    PAnaya.Y -= 10;

                    if (DireccionAn == true)
                        banderaAn = 20;

                    if (DireccionAn == false)
                        banderaAn = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 2 && Inmovil != true)
            {
                if (Player2 == 2 && SpownAn == 0)
                {
                    PAnaya.X = 100;
                    DireccionAn = true;
                    SpownAn++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    DireccionAn = true;
                    PAnaya.X += 5 + DashAnaya;
                    if (tiempo % 150 == 0)
                    {
                        banderaAn++;
                        if (banderaAn > 4)
                            banderaAn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    DireccionAn = false;
                    PAnaya.X -= 5 + DashAnaya;
                    if (tiempo % 150 == 0)
                    {
                        banderaAn++;
                        if (banderaAn > 4)
                            banderaAn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    PAnaya.Y -= 10;

                    if (DireccionAn == true)
                        banderaAn = 20;

                    if (DireccionAn == false)
                        banderaAn = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BAnaya.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 2)
                {
                    if (DireccionAn == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaAn = 0;

                    if (DireccionAn == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaAn = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 2)
                {
                    if (DireccionAn == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaAn = 0;

                    if (DireccionAn == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaAn = 0;
                }
                //----------------------------------------Jugador 2//
            }
            //Abilidades de Quiroz 1 y 2--------------------------------------//
            if (Player1 == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaAn = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionAn == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PAnaya.X -= 5;

                    if (DireccionAn == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PAnaya.X += 5;

                    banderaAn = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.I) && ActivarDash == true)
                    banderaAn = 23;
            }

            if (Player2 == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaAn = 21;


                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionAn == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PAnaya.X -= 5;

                    if (DireccionAn == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PAnaya.X += 5;

                    banderaAn = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.T) && ActivarDash == true)
                    banderaAn = 23;
            }
            //--------------------------------------Abilidades de Quiroz 1 y 2//


            //Si no esta en las plataformas caera al basio
            if (!BAnaya.Intersects(BPlataformaGameTime))
                caeAn = true;

            else
            {
                caeAn = false;
                masaAn = 5f;
                tiemposueltoAn = 0;
                timeUPAn = 0.05f;
            }
            if (caeAn == true)
            {
                tiemposueltoAn += timeUPAn;
                PAnaya.Y = PAnaya.Y + (masaAn * tiemposueltoAn);
            }



            int contador1An;
            for (contador1An = 0; contador1An < ListaDisparosDerAn.Count; contador1An++)
            {
                if (ListaDisparosDerAn[contador1An].posDisparoDerAn.X > 0)
                {
                    disparoDerAn = ListaDisparosDerAn[contador1An];
                    disparoDerAn.posDisparoDerAn = new Vector2(ListaDisparosDerAn[contador1An].posDisparoDerAn.X + ListaDisparosDerAn[contador1An].velDiaparoDerAn, ListaDisparosDerAn[contador1An].posDisparoDerAn.Y);
                    disparoDerAn.velDiaparoDerAn += 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosDerAn[contador1An] = disparoDerAn;

                    if (Player1 == 2)
                    {
                        if (ListaDisparosDerAn[contador1An].posDisparoDerAn.X + ListaDisparosDerAn[contador1An].disparoDerAn.Width >= pos_JugadorGameTime2.X + 30 &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width - 40 &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosDerAn.RemoveAt(contador1An);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 2)
                    {
                        if (ListaDisparosDerAn[contador1An].posDisparoDerAn.X + ListaDisparosDerAn[contador1An].disparoDerAn.Width >= pos_JugadorGameTime1.X + 30 &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width - 40 &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosDerAn[contador1An].posDisparoDerAn.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosDerAn.RemoveAt(contador1An);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosDerAn.RemoveAt(contador1An);
                }
            }
            int contador2An;
            for (contador2An = 0; contador2An < ListaDisparosIzqAn.Count; contador2An++)
            {
                if (ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X > 0)
                {
                    disparoIzqAn = ListaDisparosIzqAn[contador2An];
                    disparoIzqAn.posDisparoIzqAn = new Vector2(ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X + ListaDisparosIzqAn[contador2An].velDiaparoIzqAn, ListaDisparosIzqAn[contador2An].posDisparoIzqAn.Y);
                    disparoIzqAn.velDiaparoIzqAn -= 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosIzqAn[contador2An] = disparoIzqAn;

                    if (Player1 == 2)
                    {
                        if (ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X + ListaDisparosIzqAn[contador2An].disparoIzqAn.Width >= pos_JugadorGameTime2.X + 30 &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width - 40 &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosIzqAn.RemoveAt(contador2An);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 2)
                    {
                        if (ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X + ListaDisparosIzqAn[contador2An].disparoIzqAn.Width >= pos_JugadorGameTime1.X + 30 &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width - 40 &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosIzqAn[contador2An].posDisparoIzqAn.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosIzqAn.RemoveAt(contador2An);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosIzqAn.RemoveAt(contador2An);
                }
            }
        }





        void Zamarripa(GameTime gameTime)
        {
            //Jugador es igual 1 -----------------------------------------------------------//
            if (Player1 == 3 && Inmovil != true)
            {
                if (Player1 == 3 && SpownZa == 0)
                {
                    PZama.X = 1200;
                    DireccionZa = false;
                    SpownZa++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    DireccionZa = true;
                    PZama.X += 5;
                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaZa++;
                        if (banderaZa > 3)
                            banderaZa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    DireccionZa = false;
                    PZama.X -= 5;
                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaZa++;
                        if (banderaZa > 3)
                            banderaZa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    PZama.Y -= 10;
                    pos_Gancho.Y = PZama.Y + 130;

                    if (DireccionZa == true)
                        banderaZa = 20;

                    if (DireccionZa == false)
                        banderaZa = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 3 && Inmovil != true)
            {
                if (Player2 == 3 && SpownZa == 0)
                {
                    PZama.X = 100;
                    DireccionZa = true;
                    SpownZa++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    DireccionZa = true;
                    PZama.X += 5;
                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaZa++;
                        if (banderaZa > 3)
                            banderaZa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    DireccionZa = false;
                    PZama.X -= 5;
                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaZa++;
                        if (banderaZa > 3)
                            banderaZa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    PZama.Y -= 10;
                    pos_Gancho.Y = PZama.Y + 130;

                    if (DireccionZa == true)
                        banderaZa = 20;

                    if (DireccionZa == false)
                        banderaZa = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BZama.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 3)
                {
                    if (DireccionZa == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaZa = 0;

                    if (DireccionZa == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaZa = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 3)
                {
                    if (DireccionZa == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaZa = 0;

                    if (DireccionZa == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaZa = 0;
                }
                //----------------------------------------Jugador 2//
            }

            //Abilidades de Zamarripa 1 y 2--------------------------------------//
            if (Player1 == 3)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaZa = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionZa == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PZama.X -= 5;

                    if (DireccionZa == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PZama.X += 5;

                    banderaZa = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.I))
                {
                    if (DireccionZa == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PZama.X -= 5;

                    if (DireccionZa == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PZama.X += 5;

                    banderaZa = 22;
                    if (DireccionZa == true)
                        ZamaGanchoDer(gameTime);

                    if (DireccionZa == false)
                        ZamaGanchoIzq(gameTime);
                }
            }

            if (Player2 == 3)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaZa = 21;


                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionZa == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PZama.X -= 5;

                    if (DireccionZa == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PZama.X += 5;

                    banderaZa = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    if (DireccionZa == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PZama.X -= 5;

                    if (DireccionZa == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PZama.X += 5;

                    banderaZa = 22;
                    if (DireccionZa == true)
                        ZamaGanchoDer(gameTime);

                    if (DireccionZa == false)
                        ZamaGanchoIzq(gameTime);
                }
            }
            //--------------------------------------Abilidades de Zamarripa 1 y 2//


            //Si no esta en las plataformas caera al basio
            if (!BZama.Intersects(BPlataformaGameTime))
                caeZA = true;

            else
            {
                caeZA = false;
                masaZA = 5f;
                tiemposueltoZA = 0;
                timeUPZA = 0.05f;
            }
            if (caeZA == true)
            {
                tiemposueltoZA += timeUPZA;
                PZama.Y = PZama.Y + (masaZA * tiemposueltoZA);
                pos_Gancho.Y = PZama.Y + 130;
            }


            //Disparo Izquierda---------------
            for (int i = 0; i < ListaDisparos1.Count; i++)
            {
                if (ListaDisparos1[i].posRayo1.X > 0)
                {
                    disparo1 = ListaDisparos1[i];
                    disparo1.posRayo1 = new Vector2(ListaDisparos1[i].posRayo1.X - ListaDisparos1[i].velRayo1, ListaDisparos1[i].posRayo1.Y);
                    disparo1.rotacion1 += 0.3f;
                    if (disparo1.rotacion1 == 360)
                        disparo1.rotacion1 = 0;

                    disparo1.velRayo1 += 0.38f;
                    ListaDisparos1[i] = disparo1;

                    if(Player1 == 3)
                    {
                        if (ListaDisparos1[i].posRayo1.X + ListaDisparos1[i].rayo1.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos1[i].posRayo1.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos1[i].posRayo1.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos1[i].posRayo1.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos1.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 3)
                    {
                        if (ListaDisparos1[i].posRayo1.X + ListaDisparos1[i].rayo1.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos1[i].posRayo1.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos1[i].posRayo1.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos1[i].posRayo1.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos1.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos1.RemoveAt(i);
                }
            }

            //Disparo Drecha---------------
            for (int i = 0; i < ListaDisparos2.Count; i++)
            {
                if (ListaDisparos2[i].posRayo2.X > 0)
                {
                    disparo2 = ListaDisparos2[i];
                    disparo2.posRayo2 = new Vector2(ListaDisparos2[i].posRayo2.X + ListaDisparos2[i].velRayo2, ListaDisparos2[i].posRayo2.Y);
                    disparo2.rotacion2 += 0.3f;
                    if (disparo2.rotacion2 == 360)
                        disparo2.rotacion2 = 0;

                    disparo2.velRayo2 += 0.38f;
                    ListaDisparos2[i] = disparo2;

                    if (Player1 == 3)
                    {
                        if (ListaDisparos2[i].posRayo2.X + ListaDisparos2[i].rayo2.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos2[i].posRayo2.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos2[i].posRayo2.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos2[i].posRayo2.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos2.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 3)
                    {
                        if (ListaDisparos2[i].posRayo2.X + ListaDisparos2[i].rayo2.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos2[i].posRayo2.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos2[i].posRayo2.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos2[i].posRayo2.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos2.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos2.RemoveAt(i);
                }
            }
        }
        //----------------------------------------------------------------------------Zamarripa//



        //Guillen------------------------------------------------------------------------------//
        void Guillen(GameTime gameTime)
        {
            //Jugador es igual 1 -----------------------------------------------------------//
            if (Player1 == 4)
            {
                if (Player1 == 4 && SpownGn == 0)
                {
                    PGuillen.X = 1200;
                    DireccionGn = false;
                    SpownGn++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && NoCaminarGn == false)
                {
                    DireccionGn = true;
                    PGuillen.X += 5;
                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaGn++;
                        if (banderaGn > 4)
                            banderaGn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) && NoCaminarGn == false)
                {
                    DireccionGn = false;
                    PGuillen.X -= 5;
                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);
                    if (tiempo % 150 == 0)
                    {
                        banderaGn++;
                        if (banderaGn > 4)
                            banderaGn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && NoCaminarGn == false)
                {
                    PGuillen.Y -= 10;
                    pos_reloj.Y = PGuillen.Y;

                    if (DireccionGn == true)
                        banderaGn = 20;

                    if (DireccionGn == false)
                        banderaGn = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 4)
            {
                if (Player2 == 4 && SpownGn == 0)
                {
                    PGuillen.X = 100;
                    DireccionGn = true;
                    SpownGn++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) && NoCaminarGn == false)
                {
                    DireccionGn = true;
                    PGuillen.X += 5;
                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);

                    if (tiempo % 150 == 0)
                    {
                        banderaGn++;
                        if (banderaGn > 4)
                            banderaGn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && NoCaminarGn == false)
                {
                    DireccionGn = false;
                    PGuillen.X -= 5;
                    pos_reloj = new Vector2(PGuillen.X, PGuillen.Y + 130);

                    if (tiempo % 150 == 0)
                    {
                        banderaGn++;
                        if (banderaGn > 4)
                            banderaGn = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W) && NoCaminarGn == false)
                {
                    PGuillen.Y -= 10;
                    pos_reloj.Y = PGuillen.Y;

                    if (DireccionGn == true)
                        banderaGn = 20;

                    if (DireccionGn == false)
                        banderaGn = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BGuillen.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 4)
                {
                    if (DireccionGn == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaGn = 0;

                    if (DireccionGn == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaGn = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 4)
                {
                    if (DireccionGn == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaGn = 0;

                    if (DireccionGn == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaGn = 0;
                }
                //----------------------------------------Jugador 2//
            }

            //Abilidades de Zamarripa 1 y 2--------------------------------------//
            if (Player1 == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaGn = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionGn == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PGuillen.X -= 5;

                    if (DireccionGn == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PGuillen.X += 5;

                    banderaGn = 22;
                }
            }

            if (Player2 == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaGn = 21;


                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionGn == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PGuillen.X -= 5;

                    if (DireccionGn == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PGuillen.X += 5;

                    banderaGn = 22;
                }
            }
            //--------------------------------------Abilidades de Zamarripa 1 y 2//

            
            //Si no esta en las plataformas caera al basio
            if (!BGuillen.Intersects(BPlataformaGameTime))
                caeGn = true;

            else
            {
                caeGn = false;
                masaGn = 5f;
                tiemposueltoGn = 0;
                timeUPGn = 0.05f;
            }
            if (caeGn == true)
            {
                tiemposueltoGn += timeUPGn;
                PGuillen.Y = PGuillen.Y + (masaGn * tiemposueltoGn);
                pos_reloj.Y = PGuillen.Y;
            }


            //Disparo derecha---------------
            for (int i = 0; i < ListaDisparos_IzqGn.Count; i++)
            {
                if (ListaDisparos_IzqGn[i].posRayo_IzqGn.X > 0)
                {
                    disparo_IzqGn = ListaDisparos_IzqGn[i];
                    disparo_IzqGn.posRayo_IzqGn = new Vector2(ListaDisparos_IzqGn[i].posRayo_IzqGn.X - ListaDisparos_IzqGn[i].velRayo_IzqGn, ListaDisparos_IzqGn[i].posRayo_IzqGn.Y);
                    disparo_IzqGn.rotacion_IzqGn += 0.3f;
                    if (disparo_IzqGn.rotacion_IzqGn == 360)
                        disparo_IzqGn.rotacion_IzqGn = 0;

                    disparo_IzqGn.velRayo_IzqGn += 0.38f;
                    ListaDisparos_IzqGn[i] = disparo_IzqGn;

                    if(Player1 == 4)
                    {
                        if (ListaDisparos_IzqGn[i].posRayo_IzqGn.X + ListaDisparos_IzqGn[i].rayo_IzqGn.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos_IzqGn.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 4)
                    {
                        if (ListaDisparos_IzqGn[i].posRayo_IzqGn.X + ListaDisparos_IzqGn[i].rayo_IzqGn.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos_IzqGn[i].posRayo_IzqGn.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos_IzqGn.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos_IzqGn.RemoveAt(i);
                }
            }
            
            //Disparo izquierda---------------
            for (int i = 0; i < ListaDisparos_DerGn.Count; i++)
            {
                if (ListaDisparos_DerGn[i].posRayo_DerGn.X > 0)
                {
                    disparo_DerGn = ListaDisparos_DerGn[i];
                    disparo_DerGn.posRayo_DerGn = new Vector2(ListaDisparos_DerGn[i].posRayo_DerGn.X + ListaDisparos_DerGn[i].velRayo_DerGn, ListaDisparos_DerGn[i].posRayo_DerGn.Y);
                    disparo_DerGn.rotacion_DerGn += 0.3f;
                    if (disparo_DerGn.rotacion_DerGn == 360)
                        disparo_DerGn.rotacion_DerGn = 0;

                    disparo_DerGn.velRayo_DerGn += 0.38f;
                    ListaDisparos_DerGn[i] = disparo_DerGn;

                    if (Player1 == 4)
                    {
                        if (ListaDisparos_DerGn[i].posRayo_DerGn.X + ListaDisparos_DerGn[i].rayo_DerGn.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos_DerGn.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 4)
                    {
                        if (ListaDisparos_DerGn[i].posRayo_DerGn.X + ListaDisparos_DerGn[i].rayo_DerGn.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos_DerGn[i].posRayo_DerGn.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos_DerGn.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos_DerGn.RemoveAt(i);
                }
            }
        }
        //------------------------------------------------------------------------------Guillen//




        //Cañez------------------------------------------------------------------------------//
        void Canez(GameTime gameTime)
        {
            if (Player1 == 5 && Inmovil != true)
            {
                if (Player1 == 5 && SpownCz == 0)
                {
                    PCanez.X = 1200;
                    DireccionCz = false;
                    SpownCz++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    DireccionCz = true;
                    PCanez.X += 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaCz++;
                        if (banderaCz > 5)
                            banderaCz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    DireccionCz = false;
                    PCanez.X -= 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaCz++;
                        if (banderaCz > 5)
                            banderaCz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    PCanez.Y -= 10;

                    if (DireccionCz == true)
                        banderaCz = 20;

                    if (DireccionCz == false)
                        banderaCz = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 5 && Inmovil != true)
            {
                if (Player2 == 5 && SpownCz == 0)
                {
                    PCanez.X = 100;
                    DireccionCz = true;
                    SpownCz++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    DireccionCz = true;
                    PCanez.X += 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaCz++;
                        if (banderaCz > 5)
                            banderaCz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    DireccionCz = false;
                    PCanez.X -= 5;
                    if (tiempo % 150 == 0)
                    {
                        banderaCz++;
                        if (banderaCz > 5)
                            banderaCz = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    PCanez.Y -= 10;

                    if (DireccionCz == true)
                        banderaCz = 20;

                    if (DireccionCz == false)
                        banderaCz = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BCanez.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 5)
                {
                    if (DireccionCz == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaCz = 0;

                    if (DireccionCz == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaCz = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 5)
                {
                    if (DireccionCz == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaCz = 0;

                    if (DireccionCz == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaCz = 0;
                }
                //----------------------------------------Jugador 2//
            }
            //Abilidades de Quiroz 1 y 2--------------------------------------//
            if (Player1 == 5)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaCz = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionCz == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PCanez.X -= 5;

                    if (DireccionCz == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PCanez.X += 5;

                    banderaCz = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.I))
                {
                    if (DireccionCz == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PCanez.X -= 5;

                    if (DireccionCz == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PCanez.X += 5;

                    banderaCz = 23;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.U))
                    banderaCz = 30;
            }

            if (Player2 == 5)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaCz = 21;


                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionCz == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PCanez.X -= 5;

                    if (DireccionCz == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PCanez.X += 5;

                    banderaCz = 22;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    if (DireccionCz == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PCanez.X -= 5;

                    if (DireccionCz == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PCanez.X += 5;

                    banderaCz = 23;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Y))
                    banderaCz = 30;
            }
            //--------------------------------------Abilidades de Quiroz 1 y 2//


            //Si no esta en las plataformas caera al basio
            if (!BCanez.Intersects(BPlataformaGameTime))
                caeCz = true;

            else
            {
                caeCz = false;
                masaCz = 5f;
                tiemposueltoCz = 0;
                timeUPCz = 0.05f;
            }
            if (caeCz == true)
            {
                tiemposueltoCz += timeUPCz;
                PCanez.Y = PCanez.Y + (masaCz * tiemposueltoCz);
            }



            int contador1Cz;
            for (contador1Cz = 0; contador1Cz < ListaDisparosDerCz.Count; contador1Cz++)
            {
                if (ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X > 0)
                {
                    disparoDerCz = ListaDisparosDerCz[contador1Cz];
                    disparoDerCz.posDisparoDerCz = new Vector2(ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X + ListaDisparosDerCz[contador1Cz].velDiaparoDerCz, ListaDisparosDerCz[contador1Cz].posDisparoDerCz.Y);
                    disparoDerCz.velDiaparoDerCz += 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosDerCz[contador1Cz] = disparoDerCz;

                    if (Player1 == 5)
                    {
                        if(ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X + ListaDisparosDerCz[contador1Cz].disparoDerCz.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosDerCz.RemoveAt(contador1Cz);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 5)
                    {
                        if (ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X + ListaDisparosDerCz[contador1Cz].disparoDerCz.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosDerCz[contador1Cz].posDisparoDerCz.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosDerCz.RemoveAt(contador1Cz);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosDerCz.RemoveAt(contador1Cz);
                }
            }
            int contador2Cz;
            for (contador2Cz = 0; contador2Cz < ListaDisparosIzqCz.Count; contador2Cz++)
            {
                if (ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X > 0)
                {
                    disparoIzqCz = ListaDisparosIzqCz[contador2Cz];
                    disparoIzqCz.posDisparoIzqCz = new Vector2(ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X + ListaDisparosIzqCz[contador2Cz].velDiaparoIzqCz, ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.Y);
                    disparoIzqCz.velDiaparoIzqCz -= 0.58f; // -= es para la izquierda y += es para la derecha
                    ListaDisparosIzqCz[contador2Cz] = disparoIzqCz;

                    if (Player1 == 5)
                    {
                        if (ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X + ListaDisparosIzqCz[contador2Cz].disparoIzqCz.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparosIzqCz.RemoveAt(contador2Cz);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 5)
                    {
                        if (ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X + ListaDisparosIzqCz[contador2Cz].disparoIzqCz.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparosIzqCz[contador2Cz].posDisparoIzqCz.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparosIzqCz.RemoveAt(contador2Cz);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparosIzqCz.RemoveAt(contador2Cz);
                }
            }
        }
        //------------------------------------------------------------------------------Cañez//





        //Castruita------------------------------------------------------------------------------//
        void Castruita(GameTime gameTime)
        {
            //Jugador es igual 1 -----------------------------------------------------------//
            if (Player1 == 6 && Inmovil != true)
            {
                if (Player1 == 6 && SpownCa == 0)
                {
                    PCastru.X = 1100;
                    DireccionCa = false;
                    SpownCa++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right) && NoCaminarCa == false)
                {
                    DireccionCa = true;
                    PCastru.X += 5 + CastruHab2;
                    pos_GranoCafe = new Vector2(PCastru.X + 50, PCastru.Y - 50);
                    if (tiempo % 150 == 0)
                    {
                        banderaCa++;
                        if (banderaCa > 4)
                            banderaCa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) && NoCaminarCa == false)
                {
                    DireccionCa = false;
                    PCastru.X -= 5 + CastruHab2;
                    pos_GranoCafe = new Vector2(PCastru.X + 50, PCastru.Y - 50);
                    if (tiempo % 150 == 0)
                    {
                        banderaCa++;
                        if (banderaCa > 4)
                            banderaCa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    PCastru.Y -= 10;
                    pos_GranoCafe.Y = PCastru.Y - 50;

                    if (DireccionCa == true)
                        banderaCa = 20;

                    if (DireccionCa == false)
                        banderaCa = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 1 //
            //Jugador es igual 2 -----------------------------------------------------------//
            if (Player2 == 6 && Inmovil != true)
            {
                if (Player2 == 6 && SpownCa == 0)
                {
                    PCastru.X = 100;
                    DireccionCa = true;
                    SpownCa++;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) && NoCaminarCa == false)
                {
                    DireccionCa = true;
                    PCastru.X += 5 + CastruHab2;
                    pos_GranoCafe = new Vector2(PCastru.X + 50, PCastru.Y - 50);

                    if (tiempo % 150 == 0)
                    {
                        banderaCa++;
                        if (banderaCa > 4)
                            banderaCa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && NoCaminarCa == false)
                {
                    DireccionCa = false;
                    PCastru.X -= 5 + CastruHab2;
                    pos_GranoCafe = new Vector2(PCastru.X + 50, PCastru.Y - 50);

                    if (tiempo % 150 == 0)
                    {
                        banderaCa++;
                        if (banderaCa > 4)
                            banderaCa = 0;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    PCastru.Y -= 10;
                    pos_GranoCafe.Y = PCastru.Y - 50;

                    if (DireccionCa == true)
                        banderaCa = 20;

                    if (DireccionCa == false)
                        banderaCa = 20;
                }
            }
            //-----------------------------------------------------------Jugador es igual 2 //

            if (BCastru.Intersects(BPlataformaGameTime))
            {
                //Jugador 1----------------------------------------//
                if (Player1 == 6)
                {
                    if (DireccionCa == true && !(Keyboard.GetState().IsKeyDown(Keys.Right)))
                        banderaCa = 0;

                    if (DireccionCa == false && !(Keyboard.GetState().IsKeyDown(Keys.Left)))
                        banderaCa = 0;
                }
                //----------------------------------------Jugador 1//
                //Jugador 2----------------------------------------//
                if (Player2 == 6)
                {
                    if (DireccionCa == true && !(Keyboard.GetState().IsKeyDown(Keys.D)))
                        banderaCa = 0;

                    if (DireccionCa == false && !(Keyboard.GetState().IsKeyDown(Keys.A)))
                        banderaCa = 0;
                }
                //----------------------------------------Jugador 2//
            }

            //Abilidades de Castruita 1 y 2--------------------------------------//
            if (Player1 == 6)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    banderaCa = 21;

                if (Keyboard.GetState().IsKeyDown(Keys.O))
                {
                    if (DireccionCa == true && Keyboard.GetState().IsKeyDown(Keys.Right))
                        PCastru.X -= 5;

                    if (DireccionCa == false && Keyboard.GetState().IsKeyDown(Keys.Left))
                        PCastru.X += 5;

                    banderaCa = 22;
                }
            }

            if (Player2 == 6)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                    banderaCa = 21;


                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if (DireccionCa == true && Keyboard.GetState().IsKeyDown(Keys.D))
                        PCastru.X -= 5;

                    if (DireccionCa == false && Keyboard.GetState().IsKeyDown(Keys.A))
                        PCastru.X += 5;

                    banderaCa = 22;
                }
            }
            //--------------------------------------Abilidades de Castruita 1 y 2//


            //Si no esta en las plataformas caera al basio
            if (!BCastru.Intersects(BPlataformaGameTime))
                caeCa = true;

            else
            {
                caeCa = false;
                masaCa = 5f;
                tiemposueltoCa = 0;
                timeUPCa = 0.05f;
            }
            if (caeCa == true)
            {
                tiemposueltoCa += timeUPCa;
                PCastru.Y = PCastru.Y + (masaCa * tiemposueltoCa);
                pos_GranoCafe.Y = PCastru.Y - 50;
            }


            //Disparo derecha---------------
            for (int i = 0; i < ListaDisparos_IzqCa.Count; i++)
            {
                if (ListaDisparos_IzqCa[i].posRayo_IzqCa.X > 0)
                {
                    disparo_IzqCa = ListaDisparos_IzqCa[i];
                    disparo_IzqCa.posRayo_IzqCa = new Vector2(ListaDisparos_IzqCa[i].posRayo_IzqCa.X - ListaDisparos_IzqCa[i].velRayo_IzqCa, ListaDisparos_IzqCa[i].posRayo_IzqCa.Y);
                    disparo_IzqCa.rotacion_IzqCa += 0.3f;
                    if (disparo_IzqCa.rotacion_IzqCa == 360)
                        disparo_IzqCa.rotacion_IzqCa = 0;

                    disparo_IzqCa.velRayo_IzqCa += 0.38f;
                    ListaDisparos_IzqCa[i] = disparo_IzqCa;

                    if(Player1 == 6)
                    {
                        if (ListaDisparos_IzqCa[i].posRayo_IzqCa.X + ListaDisparos_IzqCa[i].rayo_IzqCa.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos_IzqCa.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 6)
                    {
                        if (ListaDisparos_IzqCa[i].posRayo_IzqCa.X + ListaDisparos_IzqCa[i].rayo_IzqCa.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos_IzqCa[i].posRayo_IzqCa.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos_IzqCa.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos_IzqCa.RemoveAt(i);
                }
            }

            //Disparo izquierda---------------
            for (int i = 0; i < ListaDisparos_DerCa.Count; i++)
            {
                if (ListaDisparos_DerCa[i].posRayo_DerCa.X > 0)
                {
                    disparo_DerCa = ListaDisparos_DerCa[i];
                    disparo_DerCa.posRayo_DerCa = new Vector2(ListaDisparos_DerCa[i].posRayo_DerCa.X + ListaDisparos_DerCa[i].velRayo_DerCa, ListaDisparos_DerCa[i].posRayo_DerCa.Y);
                    disparo_DerCa.rotacion_DerCa += 0.3f;
                    if (disparo_DerCa.rotacion_DerCa == 360)
                        disparo_DerCa.rotacion_DerCa = 0;

                    disparo_DerCa.velRayo_DerCa += 0.38f;
                    ListaDisparos_DerCa[i] = disparo_DerCa;

                    if (Player1 == 6)
                    {
                        if (ListaDisparos_DerCa[i].posRayo_DerCa.X + ListaDisparos_DerCa[i].rayo_DerCa.Width >= pos_JugadorGameTime2.X &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.X <= pos_JugadorGameTime2.X + JugadorGameTime2.Width &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.Y >= pos_JugadorGameTime2.Y &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.Y <= pos_JugadorGameTime2.Y + JugadorGameTime2.Height)
                        {
                            ListaDisparos_DerCa.RemoveAt(i);
                            VidaPlayer2 -= 10;
                            pos_vida2.X -= 10;
                        }
                    }
                    if (Player2 == 6)
                    {
                        if (ListaDisparos_DerCa[i].posRayo_DerCa.X + ListaDisparos_DerCa[i].rayo_DerCa.Width >= pos_JugadorGameTime1.X &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.X <= pos_JugadorGameTime1.X + JugadorGameTime1.Width &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.Y >= pos_JugadorGameTime1.Y &&
                            ListaDisparos_DerCa[i].posRayo_DerCa.Y <= pos_JugadorGameTime1.Y + JugadorGameTime1.Height)
                        {
                            ListaDisparos_DerCa.RemoveAt(i);
                            VidaPlayer1 -= 10;
                            pos_vida1.X += 10;
                        }
                    }
                }
                else
                {
                    ListaDisparos_DerCa.RemoveAt(i);
                }
            }
        }
        //------------------------------------------------------------------------------Castruita//



        //CREAMOS LOS MOVIMIENTOS Y AVILIDADES-------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------CREAMOS LOS MOVIMIENTOS Y AVILIDADES//




















        //FUNCIONES DE LOS OBJETOS DEL VIDEOJUEGO----------------------------------------//
        //-------------------------------------------------------------------------------//
        //----------------------------------------FUNCIONES DE LOS OBJETOS DEL VIDEOJUEGO//
        //Quiroz-------------------//
        void QzDisparo_Der(GameTime gameTime)
        {
            if (QzTiempo1 == 1)
            {
                if (DireccionQZ == true)
                {
                    //Disparo de quiroz
                    if (Player1 == 1)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbDerQZ.IsKeyDown(Keys.O)))
                        {
                            disparoDerQZ.posDisparoDerQZ = new Vector2(PQuiroz.X + TQuiroz.Width, PQuiroz.Y + 100);
                            disparoDerQZ.velDiaparoDerQZ = 2.0f;
                            ListaDisparosDerQZ.Add(disparoDerQZ);

                            QzTiempo1 = 0;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbDerQZ.IsKeyDown(Keys.R)))
                        {
                            disparoDerQZ.posDisparoDerQZ = new Vector2(PQuiroz.X + TQuiroz.Width, PQuiroz.Y + 100);
                            disparoDerQZ.velDiaparoDerQZ = 2.0f;
                            ListaDisparosDerQZ.Add(disparoDerQZ);

                            QzTiempo1 = 0;
                        }
                    }
                    kbDerQZ = Keyboard.GetState();
                }
            }
        }


        void QzDisparo_Izq(GameTime gameTime)
        {
            if (QzTiempo1 == 1)
            {
                if (DireccionQZ == false)
                {
                    //Disparo de quiroz
                    if (Player1 == 1)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbIzqQZ.IsKeyDown(Keys.O)))
                        {
                            disparoIzqQZ.posDisparoIzqQZ = new Vector2(PQuiroz.X, PQuiroz.Y + 100);
                            disparoIzqQZ.velDiaparoIzqQZ = -2.0f;
                            ListaDisparosIzqQZ.Add(disparoIzqQZ);

                            QzTiempo1 = 0;
                        }
                    }
                    if (Player2 == 1)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbIzqQZ.IsKeyDown(Keys.R)))
                        {
                            disparoIzqQZ.posDisparoIzqQZ = new Vector2(PQuiroz.X, PQuiroz.Y + 100);
                            disparoIzqQZ.velDiaparoIzqQZ = -2.0f;
                            ListaDisparosIzqQZ.Add(disparoIzqQZ);

                            QzTiempo1 = 0;
                        }
                    }
                    kbIzqQZ = Keyboard.GetState();
                }
            }
        }

        

        void QuirozUltiIzq(GameTime gameTime)
        {
            if(QzTiempo3 == 45)
            {
                if (DireccionQZ == false)
                {
                    if (Player1 == 1)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U))
                        {
                            banderaQz = 22;
                            disparoUltiIzq.posRayoUltiIzq = new Vector2(PQuiroz.X, PQuiroz.Y + 100);
                            disparoUltiIzq.rotacionUltiIzq = 0.5f;
                            disparoUltiIzq.velRayoUltiIzq = 2.0f;
                            ListaDisparosUltiIzq.Add(disparoUltiIzq);

                            if (tiempo % 1000 == 0)
                            {
                                TiempoUlti++;
                                if (TiempoUlti > 5)
                                {
                                    QzTiempo3 = 0;
                                    TiempoUlti = 0;
                                }
                            }
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y))
                        {
                            banderaQz = 22;
                            disparoUltiIzq.posRayoUltiIzq = new Vector2(PQuiroz.X, PQuiroz.Y + 100);
                            disparoUltiIzq.rotacionUltiIzq = 0.5f;
                            disparoUltiIzq.velRayoUltiIzq = 2.0f;
                            ListaDisparosUltiIzq.Add(disparoUltiIzq);

                            if (tiempo % 1000 == 0)
                            {
                                TiempoUlti++;
                                if (TiempoUlti > 6)
                                {
                                    QzTiempo3 = 0;
                                    TiempoUlti = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        void QuirozUltiDer(GameTime gameTime)
        {
            if(QzTiempo3 == 45)
            {
                if (DireccionQZ == true)
                {
                    if (Player1 == 1)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U))
                        {
                            banderaQz = 22;
                            disparoUltiDer.posRayoUltiDer = new Vector2(PQuiroz.X + TQuiroz.Width, PQuiroz.Y + 100);
                            disparoUltiDer.rotacionUltiDer = 0.5f;
                            disparoUltiDer.velRayoUltiDer = 2.0f;
                            ListaDisparosUltiDer.Add(disparoUltiDer);

                            if (tiempo % 1000 == 0)
                            {
                                TiempoUlti++;
                                if (TiempoUlti > 6)
                                {
                                    QzTiempo3 = 0;
                                    TiempoUlti = 0;
                                }
                            }
                        }
                    }
                    if (Player2 == 1)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y))
                        {
                            banderaQz = 22;
                            disparoUltiDer.posRayoUltiDer = new Vector2(PQuiroz.X + TQuiroz.Width, PQuiroz.Y + 100);
                            disparoUltiDer.rotacionUltiDer = 0.5f;
                            disparoUltiDer.velRayoUltiDer = 2.0f;
                            ListaDisparosUltiDer.Add(disparoUltiDer);

                            if (tiempo % 1000 == 0)
                            {
                                TiempoUlti++;
                                if (TiempoUlti > 6)
                                {
                                    QzTiempo3 = 0;
                                    TiempoUlti = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        //-------------------Quiroz//






        void AnDisparo_Der(GameTime gameTime)
        {
            if (AnTiempo1 == 1)
            {
                if (DireccionAn == true)
                {
                    //Disparo de Anaya
                    if (Player1 == 2)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbDerAn.IsKeyDown(Keys.O)))
                        {
                            disparoDerAn.posDisparoDerAn = new Vector2(PAnaya.X + TAnaya.Width, PAnaya.Y + 80);
                            disparoDerAn.velDiaparoDerAn = 2.0f;
                            ListaDisparosDerAn.Add(disparoDerAn);
                            AnTiempo1 = 0;
                        }
                    }
                    if (Player2 == 2)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbDerAn.IsKeyDown(Keys.R)))
                        {
                            disparoDerAn.posDisparoDerAn = new Vector2(PAnaya.X + TAnaya.Width, PAnaya.Y + 80);
                            disparoDerAn.velDiaparoDerAn = 2.0f;
                            ListaDisparosDerAn.Add(disparoDerAn);
                            AnTiempo1 = 0;
                        }
                    }
                    kbDerAn = Keyboard.GetState();
                }
            }
        }


        void AnDisparo_Izq(GameTime gameTime)
        {
            if (AnTiempo1 == 1)
            {
                if (DireccionAn == false)
                {
                    //Disparo de Anaya
                    if (Player1 == 2)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbIzqAn.IsKeyDown(Keys.O)))
                        {
                            disparoIzqAn.posDisparoIzqAn = new Vector2(PAnaya.X, PAnaya.Y + 80);
                            disparoIzqAn.velDiaparoIzqAn = -2.0f;
                            ListaDisparosIzqAn.Add(disparoIzqAn);
                            AnTiempo1 = 0;
                        }
                    }
                    if (Player2 == 2)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbIzqAn.IsKeyDown(Keys.R)))
                        {
                            disparoIzqAn.posDisparoIzqAn = new Vector2(PAnaya.X, PAnaya.Y + 80);
                            disparoIzqAn.velDiaparoIzqAn = -2.0f;
                            ListaDisparosIzqAn.Add(disparoIzqAn);
                            AnTiempo1 = 0;
                        }
                    }
                    kbIzqAn = Keyboard.GetState();
                }
            }
        }





        //El gancho jalara a todos los profes a la DERECHA---------------------------------------
        void ZamaGanchoDer(GameTime gameTime)
        {
            if (ZaTiempo2 == 10)
            {
                if (Player1 == 3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.I) && !(kb1.IsKeyDown(Keys.I)))
                    {
                        LansarGancho = true;
                    }
                    if (!(Keyboard.GetState().IsKeyDown(Keys.I)) && LansarGancho == true)
                    {
                        GanchoFin = true;
                        LansarGancho = false;
                        ZaTiempo2 = 0;
                    }

                    if (LansarGancho == true)
                    {
                        //Jalar a Quiroz----------------------------------------
                        if (Player2 == 1)
                        {
                            if (!BGancho.Intersects(BQuiroz))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BQuiroz))
                            {
                                pos_Gancho.X -= 25;
                                PQuiroz.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Anaya----------------------------------------
                        if (Player2 == 2)
                        {
                            if (!BGancho.Intersects(BAnaya))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BAnaya))
                            {
                                pos_Gancho.X -= 25;
                                PAnaya.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Guillen----------------------------------------
                        if (Player2 == 4)
                        {
                            if (!BGancho.Intersects(BGuillen))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BGuillen))
                            {
                                pos_Gancho.X -= 25;
                                PGuillen.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Cañez----------------------------------------
                        if (Player2 == 5)
                        {
                            if (!BGancho.Intersects(BCanez))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BCanez))
                            {
                                pos_Gancho.X -= 25;
                                PCanez.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Castruita----------------------------------------
                        if (Player2 == 6)
                        {
                            if (!BGancho.Intersects(BCastru))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BCastru))
                            {
                                pos_Gancho.X -= 25;
                                PCastru.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                    }
                }

                if (Player2 == 3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.T))
                    {
                        LansarGancho = true;
                    }
                    if (!(Keyboard.GetState().IsKeyDown(Keys.T)) && LansarGancho == true)
                    {
                        GanchoFin = true;
                        LansarGancho = false;
                        ZaTiempo2 = 0;
                    }

                    if (LansarGancho == true)
                    {
                        //Jalar a Quiroz----------------------------------------
                        if (Player1 == 1)
                        {
                            if (!BGancho.Intersects(BQuiroz))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BQuiroz))
                            {
                                pos_Gancho.X -= 25;
                                PQuiroz.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Anaya----------------------------------------
                        if (Player1 == 2)
                        {
                            if (!BGancho.Intersects(BAnaya))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BAnaya))
                            {
                                pos_Gancho.X -= 25;
                                PAnaya.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Guillen----------------------------------------
                        if (Player1 == 4)
                        {
                            if (!BGancho.Intersects(BGuillen))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BGuillen))
                            {
                                pos_Gancho.X -= 25;
                                PGuillen.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Cañez----------------------------------------
                        if (Player1 == 5)
                        {
                            if (!BGancho.Intersects(BCanez))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BCanez))
                            {
                                pos_Gancho.X -= 25;
                                PCanez.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a CAstruita----------------------------------------
                        if (Player1 == 6)
                        {
                            if (!BGancho.Intersects(BCastru))
                                pos_Gancho.X += 25;

                            if (BGancho.Intersects(BCastru))
                            {
                                pos_Gancho.X -= 25;
                                PCastru.X -= 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                    }
                }
            }
            if (LansarGancho == false && BGancho.Intersects(BZama) && GanchoFin == true)
            {
                ZaTiempo2 = 0;
                GanchoFin = false;
            }
        }
        //El gancho jalara a todos los profes a la DERECHA---------------------------------------

        //El gancho jalara a todos los profes a la IZQUIERDA---------------------------------------
        void ZamaGanchoIzq(GameTime gameTime)
        {
            if (ZaTiempo2 == 10)
            {
                if (Player1 == 3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.I))
                    {
                        LansarGancho = true;
                    }
                    if (!(Keyboard.GetState().IsKeyDown(Keys.I)) && LansarGancho == true)
                    {
                        GanchoFin = true;
                        LansarGancho = false;
                        ZaTiempo2 = 0;
                    }

                    if (LansarGancho == true)
                    {
                        //Jalar a Quroz----------------------------------------
                        if (Player2 == 1)
                        {
                            if (!BGancho.Intersects(BQuiroz))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BQuiroz))
                            {
                                pos_Gancho.X += 25;
                                PQuiroz.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Anaya----------------------------------------
                        if (Player2 == 2)
                        {
                            if (!BGancho.Intersects(BAnaya))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BAnaya))
                            {
                                pos_Gancho.X += 25;
                                PAnaya.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Guillen----------------------------------------
                        if (Player2 == 4)
                        {
                            if (!BGancho.Intersects(BGuillen))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BGuillen))
                            {
                                pos_Gancho.X += 25;
                                PGuillen.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Cañez----------------------------------------
                        if (Player2 == 5)
                        {
                            if (!BGancho.Intersects(BCanez))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BCanez))
                            {
                                pos_Gancho.X += 25;
                                PCanez.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Castruita----------------------------------------
                        if (Player2 == 6)
                        {
                            if (!BGancho.Intersects(BCastru))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BCastru))
                            {
                                pos_Gancho.X += 25;
                                PCastru.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer2 -= 5;
                                    pos_vida2.X -= 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                    }
                }

                if (Player2 == 3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.T))
                    {
                        LansarGancho = true;
                    }
                    if (!(Keyboard.GetState().IsKeyDown(Keys.T)) && LansarGancho == true)
                    {
                        GanchoFin = true;
                        LansarGancho = false;
                        ZaTiempo2 = 0;
                    }

                    if (LansarGancho == true)
                    {
                        //Jalar a Quiroz----------------------------------------
                        if (Player1 == 1)
                        {
                            if (!BGancho.Intersects(BQuiroz))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BQuiroz))
                            {
                                pos_Gancho.X += 25;
                                PQuiroz.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Anaya----------------------------------------
                        if (Player1 == 2)
                        {
                            if (!BGancho.Intersects(BAnaya))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BAnaya))
                            {
                                pos_Gancho.X += 25;
                                PAnaya.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Guillen----------------------------------------
                        if (Player1 == 4)
                        {
                            if (!BGancho.Intersects(BGuillen))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BGuillen))
                            {
                                pos_Gancho.X += 25;
                                PGuillen.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Cañez----------------------------------------
                        if (Player1 == 5)
                        {
                            if (!BGancho.Intersects(BCanez))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BCanez))
                            {
                                pos_Gancho.X += 25;
                                PCanez.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                        //Jalar a Castruita----------------------------------------
                        if (Player1 == 6)
                        {
                            if (!BGancho.Intersects(BCastru))
                                pos_Gancho.X -= 25;

                            if (BGancho.Intersects(BCastru))
                            {
                                pos_Gancho.X += 25;
                                PCastru.X += 25;

                                if (BGancho.Intersects(BZama))
                                {
                                    LansarGancho = false;
                                    pos_Gancho = new Vector2(PZama.X, PZama.Y + 130);
                                    VidaPlayer1 -= 5;
                                    pos_vida1.X += 5;
                                    GanchoFin = true;
                                }
                            }
                        }
                    }
                }
            }
            if (LansarGancho == false && BGancho.Intersects(BZama) && GanchoFin == true)
            {
                ZaTiempo2 = 0;
                GanchoFin = false;
            }
        }
        //El gancho jalara a todos los profes a la IZQUIERDA---------------------------------------




        //Zamarripa-------------------//
        void ZaDisparoIzq(GameTime gameTime)
        {
            if (ZaTiempo1 == 1)
            {
                if (DireccionZa == false)
                {
                    if (Player1 == 3)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.O) && !(kbM1.IsKeyDown(Keys.O)))
                        {
                            disparo1.posRayo1 = new Vector2(PZama.X, PZama.Y + 140);
                            disparo1.rotacion1 = 0.5f;
                            disparo1.velRayo1 = 2.0f;
                            ListaDisparos1.Add(disparo1);
                            ZaTiempo1 = 0;
                        }
                    }
                    if (Player2 == 3)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.R) && !(kbM1.IsKeyDown(Keys.R)))
                        {
                            disparo1.posRayo1 = new Vector2(PZama.X, PZama.Y + 140);
                            disparo1.rotacion1 = 0.5f;
                            disparo1.velRayo1 = 2.0f;
                            ListaDisparos1.Add(disparo1);
                            ZaTiempo1 = 0;
                        }
                    }
                }
                kbM1 = Keyboard.GetState();
            }
        }

        void ZaDisparoDer(GameTime gameTime)
        {
            if (ZaTiempo1 == 1)
            {
                if (DireccionZa == true)
                {
                    if (Player1 == 3)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kb2.IsKeyDown(Keys.O)))
                        {
                            disparo2.posRayo2 = new Vector2(PZama.X + TZama.Width, PZama.Y + 140);
                            disparo2.rotacion2 = 0.5f;
                            disparo2.velRayo2 = 2.0f;
                            ListaDisparos2.Add(disparo2);
                            ZaTiempo1 = 0;
                        }
                    }
                    if (Player2 == 3)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kb2.IsKeyDown(Keys.R)))
                        {
                            disparo2.posRayo2 = new Vector2(PZama.X + TZama.Width, PZama.Y + 140);
                            disparo2.rotacion2 = 0.5f;
                            disparo2.velRayo2 = 2.0f;
                            ListaDisparos2.Add(disparo2);
                            ZaTiempo1 = 0;
                        }
                    }
                }
                kb2 = Keyboard.GetState();
            }
        }
        //-------------------Zamarripa//










        //Guillen-------------------//

        void GnDisparoIzq(GameTime gameTime)
        {
            if (GnTiempo1 == 1)
            {
                if (DireccionGn == false)
                {
                    if (Player1 == 4)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kb1Gn.IsKeyDown(Keys.O)))
                        {
                            disparo_IzqGn.posRayo_IzqGn = new Vector2(PGuillen.X, PGuillen.Y + 140);
                            disparo_IzqGn.rotacion_IzqGn = 0.5f;
                            disparo_IzqGn.velRayo_IzqGn = 2.0f;
                            ListaDisparos_IzqGn.Add(disparo_IzqGn);
                            GnTiempo1 = 0;
                        }
                    }
                    if (Player2 == 4)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kb1Gn.IsKeyDown(Keys.R)))
                        {
                            disparo_IzqGn.posRayo_IzqGn = new Vector2(PGuillen.X, PGuillen.Y + 140);
                            disparo_IzqGn.rotacion_IzqGn = 0.5f;
                            disparo_IzqGn.velRayo_IzqGn = 2.0f;
                            ListaDisparos_IzqGn.Add(disparo_IzqGn);
                            GnTiempo1 = 0;
                        }
                    }
                }
                kb1Gn = Keyboard.GetState();
            }
        }

        void GnDisparoDer(GameTime gameTime)
        {
            if (GnTiempo1 == 1)
            {
                if (DireccionGn == true)
                {
                    if (Player1 == 4)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kb2Gn.IsKeyDown(Keys.O)))
                        {
                            disparo_DerGn.posRayo_DerGn = new Vector2(PGuillen.X + TGuillen.Width, PGuillen.Y + 140);
                            disparo_DerGn.rotacion_DerGn = 0.5f;
                            disparo_DerGn.velRayo_DerGn = 2.0f;
                            ListaDisparos_DerGn.Add(disparo_DerGn);
                            GnTiempo1 = 0;
                        }
                    }
                    if (Player2 == 4)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kb2Gn.IsKeyDown(Keys.R)))
                        {
                            disparo_DerGn.posRayo_DerGn = new Vector2(PGuillen.X + TGuillen.Width, PGuillen.Y + 140);
                            disparo_DerGn.rotacion_DerGn = 0.5f;
                            disparo_DerGn.velRayo_DerGn = 2.0f;
                            ListaDisparos_DerGn.Add(disparo_DerGn);
                            GnTiempo1 = 0;
                        }
                    }
                }
                kb2Gn = Keyboard.GetState();
            }
        }
        //-------------------Guillen//




        //Cañez-------------------//
        void CzDisparo_Der(GameTime gameTime)
        {
            if (CzTiempo1 == 1)
            {
                if (DireccionCz == true)
                {
                    //Disparo de Cañez
                    if (Player1 == 5)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbDerCz.IsKeyDown(Keys.O)))
                        {
                            disparoDerCz.posDisparoDerCz = new Vector2(PCanez.X + TCanez.Width, PCanez.Y + 70);
                            disparoDerCz.velDiaparoDerCz = 2.0f;
                            ListaDisparosDerCz.Add(disparoDerCz);
                            CzTiempo1 = 0;
                        }
                    }
                    if (Player2 == 5)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbDerCz.IsKeyDown(Keys.R)))
                        {
                            disparoDerCz.posDisparoDerCz = new Vector2(PCanez.X + TCanez.Width, PCanez.Y + 70);
                            disparoDerCz.velDiaparoDerCz = 2.0f;
                            ListaDisparosDerCz.Add(disparoDerCz);
                            CzTiempo1 = 0;
                        }
                    }
                    kbDerCz = Keyboard.GetState();
                }
            }
        }

        

        void ChasquidoCanez(GameTime gameTime)
        {
            if (CzTiempo3 == 45)
            {
                if (Player1 == 5)
                {
                    if (DireccionCz == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U) && !(kb2.IsKeyDown(Keys.U)))
                            ChasquidoCz = true;
                    }
                    if (DireccionCz == false)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.U) && !(kb2.IsKeyDown(Keys.U)))
                            ChasquidoCz = true;
                    }
                }
                if (Player2 == 5)
                {
                    if (DireccionCz == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y) && !(kb2.IsKeyDown(Keys.Y)))
                            ChasquidoCz = true;
                    }
                    if (DireccionCz == false)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Y) && !(kb2.IsKeyDown(Keys.Y)))
                            ChasquidoCz = true;
                    }
                }
            }

            if(ChasquidoCz == true)
            {
                if (Player1 == 5)
                {
                    VidaPlayer2 = 0;
                    pos_vida2.X -= 500;

                    VidaPlayer1 -= 400;
                    pos_vida1.X += 400;
                }
                if (Player2 == 5)
                {
                    VidaPlayer1 = 0;
                    pos_vida1.X += 500;

                    VidaPlayer2 -= 400;
                    pos_vida2.X -= 400;
                }

                CzTiempo3 = 0;
                ChasquidoCz = false;
            }
        }
        //-----------------------------------------------------------------Cañez//

        void CzDisparo_Izq(GameTime gameTime)
        {
            if (CzTiempo1 == 1)
            {
                if (DireccionCz == false)
                {
                    //Disparo de Cañez
                    if (Player1 == 5)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kbIzqCz.IsKeyDown(Keys.O)))
                        {
                            disparoIzqCz.posDisparoIzqCz = new Vector2(PCanez.X, PCanez.Y + 70);
                            disparoIzqCz.velDiaparoIzqCz = -2.0f;
                            ListaDisparosIzqCz.Add(disparoIzqCz);
                            CzTiempo1 = 0;
                        }
                    }
                    if (Player2 == 5)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kbIzqCz.IsKeyDown(Keys.R)))
                        {
                            disparoIzqCz.posDisparoIzqCz = new Vector2(PCanez.X, PCanez.Y + 70);
                            disparoIzqCz.velDiaparoIzqCz = -2.0f;
                            ListaDisparosIzqCz.Add(disparoIzqCz);
                            CzTiempo1 = 0;
                        }
                    }
                    kbIzqCz = Keyboard.GetState();
                }
            }
        }
        //-------------------Cañez//





        //Castruita-------------------//
        void CaDisparoIzq(GameTime gameTime)
        {
            if (CaTiempo1 == 1)
            {
                if (DireccionCa == false)
                {
                    if (Player1 == 6)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kb1Ca.IsKeyDown(Keys.O)))
                        {
                            disparo_IzqCa.posRayo_IzqCa = new Vector2(PCastru.X, PCastru.Y + 140);
                            disparo_IzqCa.rotacion_IzqCa = 0.5f;
                            disparo_IzqCa.velRayo_IzqCa = 2.0f;
                            ListaDisparos_IzqCa.Add(disparo_IzqCa);
                            CaTiempo1 = 0;
                        }
                    }
                    if (Player2 == 6)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kb1Ca.IsKeyDown(Keys.R)))
                        {
                            disparo_IzqCa.posRayo_IzqCa = new Vector2(PCastru.X, PCastru.Y + 140);
                            disparo_IzqCa.rotacion_IzqCa = 0.5f;
                            disparo_IzqCa.velRayo_IzqCa = 2.0f;
                            ListaDisparos_IzqCa.Add(disparo_IzqCa);
                            CaTiempo1 = 0;
                        }
                    }
                }
                kb1Ca = Keyboard.GetState();
            }
        }

        void CaDisparoDer(GameTime gameTime)
        {
            if (CaTiempo1 == 1)
            {
                if (DireccionCa == true)
                {
                    if (Player1 == 6)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.O)) && !(kb2Ca.IsKeyDown(Keys.O)))
                        {
                            disparo_DerCa.posRayo_DerCa = new Vector2(PCastru.X + TCastru.Width + 50, PCastru.Y + 140);
                            disparo_DerCa.rotacion_DerCa = 0.5f;
                            disparo_DerCa.velRayo_DerCa = 2.0f;
                            ListaDisparos_DerCa.Add(disparo_DerCa);
                            CaTiempo1 = 0;
                        }
                    }
                    if (Player2 == 6)
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.R)) && !(kb2Ca.IsKeyDown(Keys.R)))
                        {
                            disparo_DerCa.posRayo_DerCa = new Vector2(PCastru.X + TCastru.Width + 50, PCastru.Y + 140);
                            disparo_DerCa.rotacion_DerCa = 0.5f;
                            disparo_DerCa.velRayo_DerCa = 2.0f;
                            ListaDisparos_DerCa.Add(disparo_DerCa);
                            CaTiempo1 = 0;
                        }
                    }
                }
                kb2Ca = Keyboard.GetState();
            }
        }
        //-------------------Castruita//
        //FUNCIONES DE LOS OBJETOS DEL VIDEOJUEGO----------------------------------------//
        //-------------------------------------------------------------------------------//
        //----------------------------------------FUNCIONES DE LOS OBJETOS DEL VIDEOJUEGO//

















        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Red);
            spriteBatch.Begin();
            //Pintar la primera fase del menu
            if (menuState == 1)
            {
                spriteBatch.Draw(FondoMenu1, Vector2.Zero, Color.White);

                if (SelectorM1 == 1)
                    spriteBatch.Draw(Play, pos_play, Color.Gray);
                else
                    spriteBatch.Draw(Play, pos_play, Color.White);

                if (SelectorM1 == 2)
                    spriteBatch.Draw(Tutorial, pos_tutorial, Color.Gray);
                else
                    spriteBatch.Draw(Tutorial, pos_tutorial, Color.White);

                if (SelectorM1 == 3)
                    spriteBatch.Draw(Creditos, pos_creditos, Color.Gray);
                else
                    spriteBatch.Draw(Creditos, pos_creditos, Color.White);

                if (SelectorM1 == 4)
                    spriteBatch.Draw(Salir, pos_salir, Color.Gray);
                else
                    spriteBatch.Draw(Salir, pos_salir, Color.White);
            }

            //Pintar la segunda fase del menu
            if (menuState == 2)
            {
                spriteBatch.Draw(FondoMenu2, Vector2.Zero, Color.White);

                if (SeleccionarP1 == false && SeleccionarP2 == false)
                {
                    if (SelectorM2 == 1)
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.Cyan);
                    else
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.White);

                    if (SelectorM2 == 2)
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.Cyan);
                    else
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.White);

                    if (SelectorM2 == 3)
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.Cyan);
                    else
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.White);

                    if (SelectorM2 == 4)
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.Cyan);
                    else
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.White);

                    if (SelectorM2 == 5)
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.Cyan);
                    else
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.White);

                    if (SelectorM2 == 6)
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.Cyan);
                    else
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.White);
                }

                //Si ya selecciono el primer jugador, que sigue
                if (SeleccionarP1 == true && SeleccionarP2 == false)
                {
                    if (SelectorM2 == 1)
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.Red);
                    else
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.White);

                    if (SelectorM2 == 2)
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.Red);
                    else
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.White);

                    if (SelectorM2 == 3)
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.Red);
                    else
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.White);

                    if (SelectorM2 == 4)
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.Red);
                    else
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.White);

                    if (SelectorM2 == 5)
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.Red);
                    else
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.White);

                    if (SelectorM2 == 6)
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.Red);
                    else
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.White);
                }



                //Jugador 1----------------------------------------------//
                if (SeleccionarP1 == true)
                {
                    if (Player1 == 1)
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.DarkCyan);

                    if (Player1 == 2)
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.DarkCyan);

                    if (Player1 == 3)
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.DarkCyan);

                    if (Player1 == 4)
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.DarkCyan);

                    if (Player1 == 5)
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.DarkCyan);

                    if (Player1 == 6)
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.DarkCyan);
                }
                //----------------------------------------------Jugador 1//

                //Jugador 2----------------------------------------------//
                if (SeleccionarP1 == true)
                {
                    if (Player2 == 1)
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.DarkRed);

                    if (Player2 == 2)
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.DarkRed);

                    if (Player2 == 3)
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.DarkRed);

                    if (Player2 == 4)
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.DarkRed);

                    if (Player2 == 5)
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.DarkRed);

                    if (Player2 == 6)
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.DarkRed);
                }
                //----------------------------------------------Jugador 2//

                spriteBatch.Draw(botonEsc, pos_botonEsc, Color.White);
                spriteBatch.Draw(botonCancelar, pos_botonCancelar, Color.White);
                spriteBatch.Draw(botonAceptar, pos_botonAceptar, Color.White);
            }


            //Pintar la segunda fase del menu
            if (menuState == -1)
            {
                spriteBatch.Draw(FondoMenu2, Vector2.Zero, Color.White);

                if (SeleccionarP1 == false && SeleccionarP2 == false)
                {
                    if (SelectorM2 == 1)
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.Cyan);
                    else
                        spriteBatch.Draw(botonQuiroz, pos_botonQuiroz, Color.White);

                    if (SelectorM2 == 2)
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.Cyan);
                    else
                        spriteBatch.Draw(botonAnaya, pos_botonAnaya, Color.White);

                    if (SelectorM2 == 3)
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.Cyan);
                    else
                        spriteBatch.Draw(botonZamarripa, pos_botonZamarripa, Color.White);

                    if (SelectorM2 == 4)
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.Cyan);
                    else
                        spriteBatch.Draw(botonGuillen, pos_botonGuillen, Color.White);

                    if (SelectorM2 == 5)
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.Cyan);
                    else
                        spriteBatch.Draw(botonCanes, pos_botonCanes, Color.White);

                    if (SelectorM2 == 6)
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.Cyan);
                    else
                        spriteBatch.Draw(botonCastruita, pos_botonCastruita, Color.White);
                }
            }

            //Pintar la tercera fase del menu
            if (menuState == 3)
            {
                spriteBatch.Draw(FondoMenu3, Vector2.Zero, Color.White);

                if (SeleccionarStage == false)
                {
                    if (SelectorM3X == 1 && SelectorM3Y == 1)
                        spriteBatch.Draw(botonEcenario1, pos_botonEcenario1, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenario1, pos_botonEcenario1, Color.White);

                    if (SelectorM3X == 2 && SelectorM3Y == 1)
                        spriteBatch.Draw(botonEcenario2, pos_botonEcenario2, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenario2, pos_botonEcenario2, Color.White);

                    if (SelectorM3X == 1 && SelectorM3Y == 2)
                        spriteBatch.Draw(botonEcenario3, pos_botonEcenario3, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenario3, pos_botonEcenario3, Color.White);


                    if (SelectorM3X == 2 && SelectorM3Y == 2)
                        spriteBatch.Draw(botonEcenario4, pos_botonEcenario4, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenario4, pos_botonEcenario4, Color.White);

                    if (SelectorM3X == 1 && SelectorM3Y == 3)
                        spriteBatch.Draw(botonEcenario5, pos_botonEcenario5, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenario5, pos_botonEcenario5, Color.White);

                    if (SelectorM3X == 2 && SelectorM3Y == 3)
                        spriteBatch.Draw(botonEcenarioRND, pos_botonEcenarioRND, Color.Lime);
                    else
                        spriteBatch.Draw(botonEcenarioRND, pos_botonEcenarioRND, Color.White);
                }

                //Seleccionamos es Ecenario deceado
                if (SeleccionarStage == true)
                {
                    if (SelectorM3X == 1 && SelectorM3Y == 1)
                        spriteBatch.Draw(botonEcenario1, pos_botonEcenario1, Color.DarkGreen);

                    if (SelectorM3X == 2 && SelectorM3Y == 1)
                        spriteBatch.Draw(botonEcenario2, pos_botonEcenario2, Color.DarkGreen);

                    if (SelectorM3X == 1 && SelectorM3Y == 2)
                        spriteBatch.Draw(botonEcenario3, pos_botonEcenario3, Color.DarkGreen);


                    if (SelectorM3X == 2 && SelectorM3Y == 2)
                        spriteBatch.Draw(botonEcenario4, pos_botonEcenario4, Color.DarkGreen);

                    if (SelectorM3X == 1 && SelectorM3Y == 3)
                        spriteBatch.Draw(botonEcenario5, pos_botonEcenario5, Color.DarkGreen);

                    if (SelectorM3X == 2 && SelectorM3Y == 3)
                        spriteBatch.Draw(botonEcenarioRND, pos_botonEcenarioRND, Color.DarkGreen);
                }

                spriteBatch.Draw(botonEsc, pos_botonEsc, Color.White);
                spriteBatch.Draw(botonCancelar, pos_botonCancelar, Color.White);
                spriteBatch.Draw(botonAceptar, pos_botonAceptar, Color.White);
            }

            //--------------------------------------------------------------------------------------------------//
            //---------------------------------------Pintamos el juego------------------------------------------//
            //--------------------------------------------------------------------------------------------------//
            if (menuState == 4 || menuState == 5 || menuState == 6)
            {
                spriteBatch.Draw(vida1, pos_vida1, Color.White);
                spriteBatch.Draw(vida2, pos_vida2, Color.White);

                //Escenario a cargar------------------------------//
                if (BanderaEscenarios == 1)
                {
                    escenario1.Draw(spriteBatch);
                }

                if (BanderaEscenarios == 2)
                {
                    escenario2.Draw(spriteBatch);
                }

                if (BanderaEscenarios == 3)
                {
                    escenario3.Draw(spriteBatch);
                }

                if (BanderaEscenarios == 4)
                {
                    escenario4.Draw(spriteBatch);
                }

                if (BanderaEscenarios == 5)
                {
                    escenario5.Draw(spriteBatch);
                }
                //------------------------------Escenario a cargar//
                //JUGDOR 1 y JUGADOR 2
                //Pintar a Quiroz------------------------------------------------//
                if (Player1 == 1 || Player2 == 1)
                {
                    foreach (DatosDisparoDerQZ r in ListaDisparosDerQZ)
                    {
                        spriteBatch.Draw(r.disparoDerQZ, r.posDisparoDerQZ, Color.White);
                    }

                    foreach (DatosDisparoIzqQZ r in ListaDisparosIzqQZ)
                    {
                        spriteBatch.Draw(r.disparoIzqQZ, r.posDisparoIzqQZ, Color.White);
                    }


                    foreach (DatosDisparoUltiIzq r in ListaDisparosUltiIzq)
                    {
                        spriteBatch.Draw(r.rayoUltiIzq, r.posRayoUltiIzq, null, Color.White, r.rotacionUltiIzq, new Vector2(r.rayoUltiIzq.Width / 2, r.rayoUltiIzq.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }

                    foreach (DatosDisparoUltiDer r in ListaDisparosUltiDer)
                    {
                        spriteBatch.Draw(r.rayoUltiDer, r.posRayoUltiDer, null, Color.White, r.rotacionUltiDer, new Vector2(r.rayoUltiDer.Width / 2, r.rayoUltiDer.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }


                    if (DireccionQZ == true)
                    {
                        if (banderaQz == 0)
                            spriteBatch.Draw(Quiroz_Der, PQuiroz, Color.White);

                        if (banderaQz == 1)
                            spriteBatch.Draw(Quiroz_Run_Der1, PQuiroz, Color.White);

                        if (banderaQz == 2)
                            spriteBatch.Draw(Quiroz_Run_Der2, PQuiroz, Color.White);

                        if (banderaQz == 3)
                            spriteBatch.Draw(Quiroz_Run_Der3, PQuiroz, Color.White);

                        if (banderaQz == 20)
                            spriteBatch.Draw(Quiroz_Jump_Der, PQuiroz, Color.White);

                        if (banderaQz == 21)
                            spriteBatch.Draw(Quiroz_Attac1_Der, PQuiroz, Color.White);

                        if (banderaQz == 22)
                            spriteBatch.Draw(Quiroz_Attac2_Der, PQuiroz, Color.White);

                        if (banderaQz == 23)
                            spriteBatch.Draw(Quiroz_Attac3_Der, PQuiroz, Color.White);
                    }


                    if (DireccionQZ == false)
                    {
                        if (banderaQz == 0)
                            spriteBatch.Draw(Quiroz_Izq, PQuiroz, Color.White);

                        if (banderaQz == 1)
                            spriteBatch.Draw(Quiroz_Run_Izq1, PQuiroz, Color.White);

                        if (banderaQz == 2)
                            spriteBatch.Draw(Quiroz_Run_Izq2, PQuiroz, Color.White);

                        if (banderaQz == 3)
                            spriteBatch.Draw(Quiroz_Run_Izq3, PQuiroz, Color.White);

                        if (banderaQz == 20)
                            spriteBatch.Draw(Quiroz_Jump_Izq, PQuiroz, Color.White);

                        if (banderaQz == 21)
                            spriteBatch.Draw(Quiroz_Attac1_Izq, PQuiroz, Color.White);

                        if (banderaQz == 22)
                            spriteBatch.Draw(Quiroz_Attac2_Izq, PQuiroz, Color.White);

                        if (banderaQz == 23)
                            spriteBatch.Draw(Quiroz_Attac3_Izq, PQuiroz, Color.White);
                    }
                    if (Player1 == 1)
                    {
                        spriteBatch.DrawString(P1FuenteQz, QzTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteQz, QzTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteQz, QzTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 1)
                    {
                        spriteBatch.DrawString(P2FuenteQz, QzTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteQz, QzTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteQz, QzTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                //------------------------------------------------Pintar a Quiroz//

                //Pintar a Anaya------------------------------------------------//
                if (Player1 == 2 || Player2 == 2)
                {
                    foreach (DatosDisparoDerAn r in ListaDisparosDerAn)
                    {
                        spriteBatch.Draw(r.disparoDerAn, r.posDisparoDerAn, Color.White);
                    }

                    foreach (DatosDisparoIzqAn r in ListaDisparosIzqAn)
                    {
                        spriteBatch.Draw(r.disparoIzqAn, r.posDisparoIzqAn, Color.White);
                    }
                    if(TodoPoderos == false)
                    {
                        if (DireccionAn == true)
                        {
                            if (banderaAn == 0)
                                spriteBatch.Draw(Anaya_Der, PAnaya, Color.White);

                            if (banderaAn == 1)
                                spriteBatch.Draw(Anaya_Run_Der1, PAnaya, Color.White);

                            if (banderaAn == 2)
                                spriteBatch.Draw(Anaya_Run_Der2, PAnaya, Color.White);

                            if (banderaAn == 3)
                                spriteBatch.Draw(Anaya_Run_Der3, PAnaya, Color.White);

                            if (banderaAn == 4)
                                spriteBatch.Draw(Anaya_Run_Der4, PAnaya, Color.White);

                            if (banderaAn == 20)
                                spriteBatch.Draw(Anaya_Jump_Der, PAnaya, Color.White);

                            if (banderaAn == 21)
                                spriteBatch.Draw(Anaya_Attac1_Der, PAnaya, Color.White);

                            if (banderaAn == 22)
                                spriteBatch.Draw(Anaya_Attac2_Der, PAnaya, Color.White);

                            if (banderaAn == 23)
                                spriteBatch.Draw(Anaya_Attac3_Der, PAnaya, Color.White);
                        }


                        if (DireccionAn == false)
                        {
                            if (banderaAn == 0)
                                spriteBatch.Draw(Anaya_Izq, PAnaya, Color.White);

                            if (banderaAn == 1)
                                spriteBatch.Draw(Anaya_Run_Izq1, PAnaya, Color.White);

                            if (banderaAn == 2)
                                spriteBatch.Draw(Anaya_Run_Izq2, PAnaya, Color.White);

                            if (banderaAn == 3)
                                spriteBatch.Draw(Anaya_Run_Izq3, PAnaya, Color.White);

                            if (banderaAn == 4)
                                spriteBatch.Draw(Anaya_Run_Izq4, PAnaya, Color.White);

                            if (banderaAn == 20)
                                spriteBatch.Draw(Anaya_Jump_Izq, PAnaya, Color.White);

                            if (banderaAn == 21)
                                spriteBatch.Draw(Anaya_Attac1_Izq, PAnaya, Color.White);

                            if (banderaAn == 22)
                                spriteBatch.Draw(Anaya_Attac2_Izq, PAnaya, Color.White);

                            if (banderaAn == 23)
                                spriteBatch.Draw(Anaya_Attac3_Izq, PAnaya, Color.White);
                        }
                    }
                    if(TodoPoderos == true)
                    {
                        spriteBatch.Draw(Rayos1, pos_Rayos, Color.White);

                        if(DireccionAn == true)
                            spriteBatch.Draw(Anaya_Ulti_Der, PAnaya, Color.White);

                        if(DireccionAn == false)
                            spriteBatch.Draw(Anaya_Ulti_Izq, PAnaya, Color.White);
                    }
                    if (Player1 == 2)
                    {
                        spriteBatch.DrawString(P1FuenteAn, AnTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteAn, AnTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteAn, AnTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 2)
                    {
                        spriteBatch.DrawString(P2FuenteAn, AnTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteAn, AnTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteAn, AnTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                //------------------------------------------------Pintar a Anaya//

                //Pintar a Zamarripa------------------------------------------------//
                if (Player1 == 3 || Player2 == 3)
                {
                    if (StormBreaker == false)
                    {
                        foreach (DatosDisparo1 r in ListaDisparos1)
                        {
                            spriteBatch.Draw(r.rayo1, r.posRayo1, null, Color.White, r.rotacion1, new Vector2(r.rayo1.Width / 2, r.rayo1.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        }

                        foreach (DatosDisparo2 r in ListaDisparos2)
                        {
                            spriteBatch.Draw(r.rayo2, r.posRayo2, null, Color.White, r.rotacion2, new Vector2(r.rayo2.Width / 2, r.rayo2.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        }

                        if (LansarGancho == true && DireccionZa == true)
                            spriteBatch.Draw(GanchoDer, pos_Gancho, Color.White);

                        if (LansarGancho == true && DireccionZa == false)
                            spriteBatch.Draw(GanchoIzq, pos_Gancho, Color.White);

                        if (DireccionZa == true)
                        {
                            if (banderaZa == 0)
                                spriteBatch.Draw(Zamarripa_Der, PZama, Color.White);

                            if (banderaZa == 1)
                                spriteBatch.Draw(Zamarripa_Run_Der1, PZama, Color.White);

                            if (banderaZa == 2)
                                spriteBatch.Draw(Zamarripa_Run_Der2, PZama, Color.White);

                            if (banderaZa == 3)
                                spriteBatch.Draw(Zamarripa_Run_Der3, PZama, Color.White);

                            if (banderaZa == 4)
                                spriteBatch.Draw(Zamarripa_Run_Der4, PZama, Color.White);

                            if (banderaZa == 20)
                                spriteBatch.Draw(Zamarripa_Jump_Der, PZama, Color.White);

                            if (banderaZa == 21)
                                spriteBatch.Draw(Zamarripa_Attac1_Der, PZama, Color.White);

                            if (banderaZa == 22)
                                spriteBatch.Draw(Zamarripa_Attac2_Der, PZama, Color.White);
                        }


                        if (DireccionZa == false)
                        {
                            if (banderaZa == 0)
                                spriteBatch.Draw(Zamarripa_Izq, PZama, Color.White);

                            if (banderaZa == 1)
                                spriteBatch.Draw(Zamarripa_Run_Izq1, PZama, Color.White);

                            if (banderaZa == 2)
                                spriteBatch.Draw(Zamarripa_Run_Izq2, PZama, Color.White);

                            if (banderaZa == 3)
                                spriteBatch.Draw(Zamarripa_Run_Izq3, PZama, Color.White);

                            if (banderaZa == 4)
                                spriteBatch.Draw(Zamarripa_Run_Izq4, PZama, Color.White);

                            if (banderaZa == 20)
                                spriteBatch.Draw(Zamarripa_Jump_Izq, PZama, Color.White);

                            if (banderaZa == 21)
                                spriteBatch.Draw(Zamarripa_Attac1_Izq, PZama, Color.White);

                            if (banderaZa == 22)
                                spriteBatch.Draw(Zamarripa_Attac2_Izq, PZama, Color.White);
                        }
                    }
                    if (StormBreaker == true)
                    {
                        foreach (DatosDisparo1 r in ListaDisparos1)
                        {
                            spriteBatch.Draw(r.Ultirayo1, r.posRayo1, null, Color.White, r.rotacion1, new Vector2(r.rayo1.Width / 2, r.rayo1.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        }

                        foreach (DatosDisparo2 r in ListaDisparos2)
                        {
                            spriteBatch.Draw(r.Ultirayo2, r.posRayo2, null, Color.White, r.rotacion2, new Vector2(r.rayo2.Width / 2, r.rayo2.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                        }

                        if (LansarGancho == true && DireccionZa == true)
                            spriteBatch.Draw(UltiGanchoDer, pos_Gancho, Color.White);

                        if (LansarGancho == true && DireccionZa == false)
                            spriteBatch.Draw(UltiGanchoIzq, pos_Gancho, Color.White);

                        if (DireccionZa == true)
                        {
                            if (banderaZa == 0)
                                spriteBatch.Draw(UltiZamarripa_Der, PZama, Color.White);

                            if (banderaZa == 1)
                                spriteBatch.Draw(UltiZamarripa_Run_Der1, PZama, Color.White);

                            if (banderaZa == 2)
                                spriteBatch.Draw(UltiZamarripa_Run_Der2, PZama, Color.White);

                            if (banderaZa == 3)
                                spriteBatch.Draw(UltiZamarripa_Run_Der3, PZama, Color.White);

                            if (banderaZa == 4)
                                spriteBatch.Draw(UltiZamarripa_Run_Der4, PZama, Color.White);

                            if (banderaZa == 20)
                                spriteBatch.Draw(UltiZamarripa_Jump_Der, PZama, Color.White);

                            if (banderaZa == 21)
                                spriteBatch.Draw(UltiZamarripa_Attac1_Der, PZama, Color.White);

                            if (banderaZa == 22)
                                spriteBatch.Draw(UltiZamarripa_Attac2_Der, PZama, Color.White);
                        }


                        if (DireccionZa == false)
                        {
                            if (banderaZa == 0)
                                spriteBatch.Draw(UltiZamarripa_Izq, PZama, Color.White);

                            if (banderaZa == 1)
                                spriteBatch.Draw(UltiZamarripa_Run_Izq1, PZama, Color.White);

                            if (banderaZa == 2)
                                spriteBatch.Draw(UltiZamarripa_Run_Izq2, PZama, Color.White);

                            if (banderaZa == 3)
                                spriteBatch.Draw(UltiZamarripa_Run_Izq3, PZama, Color.White);

                            if (banderaZa == 4)
                                spriteBatch.Draw(UltiZamarripa_Run_Izq4, PZama, Color.White);

                            if (banderaZa == 20)
                                spriteBatch.Draw(UltiZamarripa_Jump_Izq, PZama, Color.White);

                            if (banderaZa == 21)
                                spriteBatch.Draw(UltiZamarripa_Attac1_Izq, PZama, Color.White);

                            if (banderaZa == 22)
                                spriteBatch.Draw(UltiZamarripa_Attac2_Izq, PZama, Color.White);
                        }
                    }
                    if (Player1 == 3)
                    {
                        spriteBatch.DrawString(P1FuenteZa, ZaTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteZa, ZaTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteZa, ZaTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 3)
                    {
                        spriteBatch.DrawString(P2FuenteZa, ZaTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteZa, ZaTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteZa, ZaTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                
                //------------------------------------------------Pintar a Zamarripa//


                //Pintar a Guillen------------------------------------------------//
                if (Player1 == 4 || Player2 == 4)
                {
                    foreach (DatosDisparo_IzqGn r in ListaDisparos_IzqGn)
                    {
                        spriteBatch.Draw(r.rayo_IzqGn, r.posRayo_IzqGn, null, Color.White, r.rotacion_IzqGn, new Vector2(r.rayo_IzqGn.Width / 2, r.rayo_IzqGn.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }

                    foreach (DatosDisparo_DerGn r in ListaDisparos_DerGn)
                    {
                        spriteBatch.Draw(r.rayo_DerGn, r.posRayo_DerGn, null, Color.White, r.rotacion_DerGn, new Vector2(r.rayo_DerGn.Width / 2, r.rayo_DerGn.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }

                    if (LanzarReloj == true)
                        spriteBatch.Draw(Reloj, pos_reloj, Color.White);

                    if (Invisivilidad == false)
                    {
                        if (DireccionGn == true)
                        {
                            if (banderaGn == 0)
                                spriteBatch.Draw(Guillen_Der, PGuillen, Color.White);

                            if (banderaGn == 1)
                                spriteBatch.Draw(Guillen_Run_Der1, PGuillen, Color.White);

                            if (banderaGn == 2)
                                spriteBatch.Draw(Guillen_Run_Der2, PGuillen, Color.White);

                            if (banderaGn == 3)
                                spriteBatch.Draw(Guillen_Run_Der3, PGuillen, Color.White);

                            if (banderaGn == 4)
                                spriteBatch.Draw(Guillen_Run_Der4, PGuillen, Color.White);

                            if (banderaGn == 20)
                                spriteBatch.Draw(Guillen_Jump_Der, PGuillen, Color.White);

                            if (banderaGn == 21)
                                spriteBatch.Draw(Guillen_Attac1_Der, PGuillen, Color.White);

                            if (banderaGn == 22)
                                spriteBatch.Draw(Guillen_Attac2_Der, PGuillen, Color.White);
                        }


                        if (DireccionGn == false)
                        {
                            if (banderaGn == 0)
                                spriteBatch.Draw(Guillen_Izq, PGuillen, Color.White);

                            if (banderaGn == 1)
                                spriteBatch.Draw(Guillen_Run_Izq1, PGuillen, Color.White);

                            if (banderaGn == 2)
                                spriteBatch.Draw(Guillen_Run_Izq2, PGuillen, Color.White);

                            if (banderaGn == 3)
                                spriteBatch.Draw(Guillen_Run_Izq3, PGuillen, Color.White);

                            if (banderaGn == 4)
                                spriteBatch.Draw(Guillen_Run_Izq4, PGuillen, Color.White);

                            if (banderaGn == 20)
                                spriteBatch.Draw(Guillen_Jump_Izq, PGuillen, Color.White);

                            if (banderaGn == 21)
                                spriteBatch.Draw(Guillen_Attac1_Izq, PGuillen, Color.White);

                            if (banderaGn == 22)
                                spriteBatch.Draw(Guillen_Attac2_Izq, PGuillen, Color.White);
                        }
                    }
                    if (Player1 == 4)
                    {
                        spriteBatch.DrawString(P1FuenteGn, GnTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteGn, GnTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteGn, GnTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 4)
                    {
                        spriteBatch.DrawString(P2FuenteGn, GnTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteGn, GnTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteGn, GnTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                //------------------------------------------------Pintar a Guillen//

                //Pintar a Cañez------------------------------------------------//
                if (Player1 == 5 || Player2 == 5)
                {
                    foreach (DatosDisparoDerCz r in ListaDisparosDerCz)
                    {
                        spriteBatch.Draw(r.disparoDerCz, r.posDisparoDerCz, Color.White);
                    }

                    foreach (DatosDisparoIzqCz r in ListaDisparosIzqCz)
                    {
                        spriteBatch.Draw(r.disparoIzqCz, r.posDisparoIzqCz, Color.White);
                    }

                    if (DireccionCz == true)
                    {
                        if (banderaCz == 0)
                            spriteBatch.Draw(Canez_Der, PCanez, Color.White);

                        if (banderaCz == 1)
                            spriteBatch.Draw(Canez_Run_Der1, PCanez, Color.White);

                        if (banderaCz == 2)
                            spriteBatch.Draw(Canez_Run_Der2, PCanez, Color.White);

                        if (banderaCz == 3)
                            spriteBatch.Draw(Canez_Run_Der3, PCanez, Color.White);

                        if (banderaCz == 4)
                            spriteBatch.Draw(Canez_Run_Der4, PCanez, Color.White);

                        if (banderaCz == 5)
                            spriteBatch.Draw(Canez_Run_Der5, PCanez, Color.White);

                        if (banderaCz == 20)
                            spriteBatch.Draw(Canez_Jump_Der, PCanez, Color.White);

                        if (banderaCz == 21)
                            spriteBatch.Draw(Canez_Attac1_Der, PCanez, Color.White);

                        if (banderaCz == 22)
                            spriteBatch.Draw(Canez_Attac2_Der, PCanez, Color.White);

                        if (banderaCz == 23)
                            spriteBatch.Draw(Canez_Attac3_Der, PCanez, Color.White);

                        if (banderaCz == 30)
                            spriteBatch.Draw(Canez_Ulti_Der, PCanez, Color.White);
                    }


                    if (DireccionCz == false)
                    {
                        if (banderaCz == 0)
                            spriteBatch.Draw(Canez_Izq, PCanez, Color.White);

                        if (banderaCz == 1)
                            spriteBatch.Draw(Canez_Run_Izq1, PCanez, Color.White);

                        if (banderaCz == 2)
                            spriteBatch.Draw(Canez_Run_Izq2, PCanez, Color.White);

                        if (banderaCz == 3)
                            spriteBatch.Draw(Canez_Run_Izq3, PCanez, Color.White);

                        if (banderaCz == 4)
                            spriteBatch.Draw(Canez_Run_Izq4, PCanez, Color.White);

                        if (banderaCz == 5)
                            spriteBatch.Draw(Canez_Run_Izq5, PCanez, Color.White);

                        if (banderaCz == 20)
                            spriteBatch.Draw(Canez_Jump_Izq, PCanez, Color.White);

                        if (banderaCz == 21)
                            spriteBatch.Draw(Canez_Attac1_Izq, PCanez, Color.White);

                        if (banderaCz == 22)
                            spriteBatch.Draw(Canez_Attac2_Izq, PCanez, Color.White);

                        if (banderaCz == 23)
                            spriteBatch.Draw(Canez_Attac3_Izq, PCanez, Color.White);

                        if (banderaCz == 30)
                            spriteBatch.Draw(Canez_Ulti_Izq, PCanez, Color.White);
                    }
                    if (Player1 == 5)
                    {
                        spriteBatch.DrawString(P1FuenteCz, CzTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteCz, CzTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteCz, CzTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 5)
                    {
                        spriteBatch.DrawString(P2FuenteCz, CzTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteCz, CzTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteCz, CzTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                //------------------------------------------------Pintar a Cañez//

                //Pintar a Castruita------------------------------------------------//
                if (Player1 == 6 || Player2 == 6)
                {
                    foreach (DatosDisparo_IzqCa r in ListaDisparos_IzqCa)
                    {
                        spriteBatch.Draw(r.rayo_IzqCa, r.posRayo_IzqCa, null, Color.White, r.rotacion_IzqCa, new Vector2(r.rayo_IzqCa.Width / 2, r.rayo_IzqCa.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }

                    foreach (DatosDisparo_DerCa r in ListaDisparos_DerCa)
                    {
                        spriteBatch.Draw(r.rayo_DerCa, r.posRayo_DerCa, null, Color.White, r.rotacion_DerCa, new Vector2(r.rayo_DerCa.Width / 2, r.rayo_DerCa.Height / 2), 1.0f, SpriteEffects.None, 0.0f);
                    }

                    if (LanzarGrano == true && !Explotar == true)
                        spriteBatch.Draw(GranoCafe, pos_GranoCafe, Color.White);

                    if (MostrarExplocion == true)
                        spriteBatch.Draw(explocion, new Vector2(pos_GranoCafe.X, pos_GranoCafe.Y), Color.White);

                    if (DireccionCa == true)
                    {
                        if (banderaCa == 0)
                            spriteBatch.Draw(Castru_Der, PCastru, Color.White);

                        if (banderaCa == 1)
                            spriteBatch.Draw(Castru_Run_Der1, PCastru, Color.White);

                        if (banderaCa == 2)
                            spriteBatch.Draw(Castru_Run_Der2, PCastru, Color.White);

                        if (banderaCa == 3)
                            spriteBatch.Draw(Castru_Run_Der3, PCastru, Color.White);

                        if (banderaCa == 4)
                            spriteBatch.Draw(Castru_Run_Der4, PCastru, Color.White);

                        if (banderaCa == 20)
                            spriteBatch.Draw(Castru_Jump_Der, PCastru, Color.White);

                        if (banderaCa == 22)
                          spriteBatch.Draw(Castru_Attac2_Der, PCastru, Color.White);

                      if (banderaCa == 23)
                          spriteBatch.Draw(Castru_Attac3_Der, PCastru, Color.White);
                    }


                    if (DireccionCa == false)
                    {
                        if (banderaCa == 0)
                            spriteBatch.Draw(Castru_Izq, PCastru, Color.White);

                        if (banderaCa == 1)
                            spriteBatch.Draw(Castru_Run_Izq1, PCastru, Color.White);

                        if (banderaCa == 2)
                            spriteBatch.Draw(Castru_Run_Izq2, PCastru, Color.White);

                        if (banderaCa == 3)
                            spriteBatch.Draw(Castru_Run_Izq3, PCastru, Color.White);

                        if (banderaCa == 4)
                            spriteBatch.Draw(Castru_Run_Izq4, PCastru, Color.White);

                        if (banderaCa == 20)
                            spriteBatch.Draw(Castru_Jump_Izq, PCastru, Color.White);

                        if (banderaCa == 22)
                           spriteBatch.Draw(Castru_Attac2_Izq, PCastru, Color.White);

                       if (banderaCa == 23)
                           spriteBatch.Draw(Castru_Attac3_Izq, PCastru, Color.White);
                    }
                    if (Player1 == 6)
                    {
                        spriteBatch.DrawString(P1FuenteCa, CaTiempo1.ToString(), new Vector2(1074, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteCa, CaTiempo2.ToString(), new Vector2(1175, 615), Color.White);
                        spriteBatch.DrawString(P1FuenteCa, CaTiempo3.ToString(), new Vector2(1280, 615), Color.White);
                    }
                    if (Player2 == 6)
                    {
                        spriteBatch.DrawString(P2FuenteCa, CaTiempo1.ToString(), new Vector2(266, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteCa, CaTiempo2.ToString(), new Vector2(169, 615), Color.White);
                        spriteBatch.DrawString(P2FuenteCa, CaTiempo3.ToString(), new Vector2(58, 615), Color.White);
                    }
                }
                //------------------------------------------------Pintar a Castruita//


                spriteBatch.Draw(BarraGeneralP1, Pos_BarraVida1, Color.White);
                spriteBatch.Draw(BarraGeneralP2, Pos_BarraVida2, Color.White);

                spriteBatch.Draw(BarraAvilidadeGeneralP1, Pos_BarraAvilidad1, Color.White);
                spriteBatch.Draw(BarraAvilidadeGeneralP2, Pos_BarraAvilidad2, Color.White);
            }
            //--------------------------------------------------------------------------------------------------//
            //---------------------------------------Pintamos el juego------------------------------------------//
            //--------------------------------------------------------------------------------------------------//


            //Pausa-------------------------------------------------------------------//
            if (menuState == 5)
            {
                spriteBatch.Draw(MenuPausa, Vector2.Zero, Color.White);

                if (SelectorM5 == 1)
                    spriteBatch.Draw(PausaVolver, pos_play, Color.Gray);
                else
                    spriteBatch.Draw(PausaVolver, pos_play, Color.White);

                if (SelectorM5 == 2)
                    spriteBatch.Draw(PausaReiniciar, pos_tutorial, Color.Gray);
                else
                    spriteBatch.Draw(PausaReiniciar, pos_tutorial, Color.White);

                if (SelectorM5 == 3)
                    spriteBatch.Draw(PausaMenu, pos_creditos, Color.Gray);
                else
                    spriteBatch.Draw(PausaMenu, pos_creditos, Color.White);
            }

            if (menuState == 6)
            {
                if (Ganador == 1)
                    spriteBatch.Draw(Win_GameTime1, Vector2.Zero, Color.White);

                if (Ganador == 2)
                    spriteBatch.Draw(Win_GameTime2, Vector2.Zero, Color.White);
            }
            //-------------------------------------------------------------------Pausa//
            //spriteBatch.DrawString(FuenteVidaPlayer2, Convert.ToString("Inmovilidad: " + Inmovil), Vector2.Zero, Color.White);
            //spriteBatch.DrawString(Fuente, Convert.ToString("Fin del juego es igual a: " + GameOver), new Vector2(0, 100), Color.White);
            //spriteBatch.DrawString(FuenteJugador1, Convert.ToString("Gano el jugador: " + Ganador), new Vector2(0, 150), Color.White);
            //spriteBatch.DrawString(FuenteJugador2, Convert.ToString("posicion del reloj: " + pos_reloj), new Vector2(0, 200), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
