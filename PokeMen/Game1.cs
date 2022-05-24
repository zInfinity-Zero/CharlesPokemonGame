using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace CharlesPokemon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player playerSprite;

        private Building home1;
        private Building home2;

        private Building lab;



        private ReadableObject sign1; 
        private ReadableObject sign2;
        private ReadableObject sign3; 
        private ReadableObject postbox1; 
        private ReadableObject postbox2;
        private ReadableObject hole;

        private Sprite[] flowerRow = new Sprite[8];

        private Tree[] hedgeRow1 = new Tree[8];
        private Tree[] hedgeRow2 = new Tree[8];

        private Tree[] treeColumn1 = new Tree [10];
        private Tree[] treeColumn2 = new Tree [10];
        private Tree[] treeRow1 = new Tree [6];
        private Tree[] treeRow2 = new Tree [6];
        private Tree[] treeRow3 = new Tree[14];

        private Tree[] crateup = new Tree[16];
        private Tree[] cratedown = new Tree[16];
        private Tree[] crateleft = new Tree[16];
        private Tree[] crateright = new Tree[16];

        private List<Tree> treeObjects = new List<Tree>();
        private List<Building> buildings = new List<Building>();
        private List<ReadableObject> signs = new List<ReadableObject>();
        private List<Sprite> skillboxes = new List<Sprite>();


        private Texture2D loadTexture;
        private Texture2D playerleft;
        private Texture2D playerright;
        private Texture2D atkt;
        private Texture2D mirrort;
        private Texture2D storet;
        private Texture2D visiont;
        private Texture2D dodget;
        private Texture2D raget;

        private Texture2D player2left;
        private Texture2D player2right;
        private Texture2D player3left;
        private Texture2D player3right;
        private Texture2D player4left;
        private Texture2D player4right;


        private InputManager iManager = new InputManager();
        private PhysicsManager pManager = new PhysicsManager();
        private Camera camera;
        private MouseManager mManager = new MouseManager();

        public bool battle = false;

        private Jokemon user;
        private Jokemon enemy;

        private Text text = new Text();
        private Text sign1text = new Text();
        private Text sign2text = new Text();
        private Text sign3text = new Text();
        private Text userattack;
        private Text enemyattack;
        private Text userdefense;
        private Text enemydefense;
        private Text userdodge;
        private Text enemydodge;
        private Text playercoins;

        private Sprite textbox;
        private Sprite skillbox1, skillbox2, skillbox3, skillbox4, skillbox5, skillbox6;
        private Sprite eskillbox1, eskillbox2, eskillbox3, eskillbox4, eskillbox5, eskillbox6;
        private Sprite door1, door2;
        private Sprite buyingskin2, buyingskin3, buyingskin4;
        private Sprite buyingskinpage;
        private Sprite buyingskin2display, buyingskin3display, buyingskin4display;
        private Sprite buybutton;

        private HealthBar healthbar;
        private HealthBar enemyhealthbar;

        private BattleSystem battlesystem = new BattleSystem();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
   
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont font = Content.Load<SpriteFont>("File");
            text = new Text(font, "Play", new Vector2((Window.ClientBounds.X / 2) - 50, (Window.ClientBounds.Y / 3) + 25), Color.White);


            

            camera = new Camera(GraphicsDevice.Viewport);
            loadTexture = Content.Load<Texture2D>("user");
            user = new Jokemon(loadTexture,new Vector2(20,400-152),new Vector2(150,304),100,10,5);
            loadTexture = Content.Load<Texture2D>("enemy");//frieza front view
            enemy = new Jokemon(loadTexture, new Vector2(645, 400-152), new Vector2(150, 304), 100, 10, 5);

            playerright = Content.Load<Texture2D>("player-removebg-preview");
            playerleft = Content.Load<Texture2D>("player-removebg-preview(left");
            player2right = Content.Load<Texture2D>("player2right");
            player2left = Content.Load<Texture2D>("player2left");
            player3right = Content.Load<Texture2D>("player3right");
            player3left = Content.Load<Texture2D>("player3left");
            player4right = Content.Load<Texture2D>("player4right");
            player4left = Content.Load<Texture2D>("player4left");
            playerSprite = new Player(playerleft, playerright, player2left, player2right, new Vector2(400, 400), new Vector2(30,50));

            loadTexture = Content.Load<Texture2D>("House");
            home1 = new Building(loadTexture, new Vector2(200, 200), new Vector2(150, 150));
            home2 = new Building(loadTexture, new Vector2(500, 200), new Vector2(150, 150));
            buildings.Add(home1);
            buildings.Add(home2);
            loadTexture = Content.Load<Texture2D>("Lab");
            lab = new Building(loadTexture, new Vector2(475,450), new Vector2(200,150));
            buildings.Add(lab);


            loadTexture = Content.Load<Texture2D>("Sign_Little");
            sign1 = new ReadableObject(loadTexture, new Vector2(150, 550), new Vector2(25,25));
            signs.Add(sign1);



            loadTexture = Content.Load<Texture2D>("Sign_Big");
            sign2 = new ReadableObject(loadTexture, new Vector2(290, 475), new Vector2(25,25));
            sign3 = new ReadableObject(loadTexture, new Vector2(565, 625), new Vector2(25,25));
            signs.Add(sign2);
            signs.Add(sign3);


            loadTexture = Content.Load<Texture2D>("Postbox");
            postbox1 = new ReadableObject(loadTexture, new Vector2(115, 265), new Vector2(25, 35));
            postbox2 = new ReadableObject(loadTexture, new Vector2(465, 265), new Vector2(25, 35));
  
            loadTexture = Content.Load<Texture2D>("127595");
            hole = new ReadableObject(loadTexture, new Vector2(360, 0), new Vector2(75, 75));



            int posX = 0;
            int posY = 500;
            int xOffset = 150;
            int yOffset = 20;
            loadTexture = Content.Load<Texture2D>("Flower_Red");


            for (int i = 0; i < flowerRow.Length; i++)
            {

                if(i % 2 != 0)
                {
                    posY = posY + yOffset;
                    posX = ((i - 1) * 12) + xOffset;
                }
                else
                {
                    posY = 500;
                    posX = (i * 12) + xOffset;

                }

                flowerRow[i] = new Sprite(loadTexture, new Vector2(posX, posY), new Vector2(25, 25));
               
                

            }


            posX = 0;
            posY = 475;
            xOffset = 150;

            loadTexture = Content.Load<Texture2D>("Tree_Little");


            for (int i = 0; i < hedgeRow1.Length; i++)
            {
                posX = (i * 20) + xOffset;

                hedgeRow1[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(25,25));


            }

    

            for (int i = 0; i < hedgeRow2.Length; i++)
            {
                posX = (i * 20) + 475;

                hedgeRow2[i] = new Tree(loadTexture, new Vector2(posX, 625), new Vector2(25, 25));
                

            }


            
            loadTexture = Content.Load<Texture2D>("Tree_Big");

            for (int i = 0; i < treeColumn1.Length; i++)
            {
               
                posX = 0;
                posY = (i * 80);
                treeColumn1[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeColumn1[i]);
            }



            for (int i = 0; i < treeColumn2.Length; i++)
            {
                posX = 740;
                posY = (i * 80);

                treeColumn2[i] = new Tree(loadTexture, new Vector2(posX, posY), new Vector2(60, 100));
                treeObjects.Add(treeColumn2[i]);


            }


            for (int i = 0; i < treeRow1.Length; i++)
            {

                posX = 50 + (i * 50);

                treeRow1[i] = new Tree(loadTexture, new Vector2(posX, 0), new Vector2(60, 100));
                treeObjects.Add(treeRow1[i]);
                


            }


            for (int i = 0; i < treeRow2.Length; i++)
            {

                posX = 440 + (i * 50);

                treeRow2[i] = new Tree(loadTexture, new Vector2(posX, 0), new Vector2(60, 100));
                treeObjects.Add(treeRow2[i]);


            }


            for (int i = 0; i < treeRow3.Length; i++)
            {

                posX = 50 + (i * 50);

                treeRow3[i] = new Tree(loadTexture, new Vector2(posX, 740), new Vector2(60, 100));
                treeObjects.Add(treeRow3[i]);


            }
            loadTexture = Content.Load<Texture2D>("crates_study_x2");
            for (int i = 0; i < crateleft.Length; i++)
            {

                posX = 0;
                posY = (i * 50);
                crateleft[i] = new Tree(loadTexture, new Vector2(posX, posY - 800), new Vector2(50, 50));
                treeObjects.Add(crateleft[i]);
            }
            for (int i = 0; i < crateright.Length; i++)
            {
                posX = 750;
                posY = (i * 50);

                crateright[i] = new Tree(loadTexture, new Vector2(posX, posY - 800), new Vector2(50, 50));
                treeObjects.Add(crateright[i]);


            }
            for (int i = 0; i < cratedown.Length; i++)
            {

                posX =   (i * 50);

                cratedown[i] = new Tree(loadTexture, new Vector2(posX, -50), new Vector2(50, 50));
                treeObjects.Add(cratedown[i]);


            }
            for (int i = 0; i < crateup.Length; i++)
            {

                posX =  (i * 50);

                crateup[i] = new Tree(loadTexture, new Vector2(posX, -800), new Vector2(50, 50));
                treeObjects.Add(crateup[i]);



            }


            loadTexture = Content.Load<Texture2D>("msg_box_10-2-2-removebg-preview");
            textbox = new Sprite(loadTexture, new Vector2(0, 550), new Vector2(800, 200));
            sign1text = new Text(font, "This is sign 1", new Vector2(50, 650), Color.White);
            sign2text = new Text(font, "This is sign 2", new Vector2(50, 650), Color.White);
            sign3text = new Text(font, "This is sign 3", new Vector2(50, 650), Color.White);

            buyingskinpage = new Sprite(loadTexture, new Vector2(0, 0), new Vector2(800, 800));

            playercoins = new Text(font, "Coins:" + playerSprite.coins.ToString(), new Vector2(50, 650), Color.White);

            atkt = Content.Load<Texture2D>("ATK");
            skillbox1 = new Sprite(atkt, new Vector2(10,10), new Vector2(100, 100));
            
            mirrort = Content.Load<Texture2D>("Mirror");
            skillbox2 = new Sprite(mirrort, new Vector2(120, 10), new Vector2(100, 100));
            storet = Content.Load<Texture2D>("Store");

            skillbox3 = new Sprite(storet, new Vector2(10, 120), new Vector2(100, 100));
            visiont = Content.Load<Texture2D>("Vision");

            skillbox4 = new Sprite(visiont, new Vector2(10, 690), new Vector2(100, 100));
            dodget = Content.Load<Texture2D>("Dodge");

            skillbox5 = new Sprite(dodget, new Vector2(10, 580), new Vector2(100, 100));
            raget = Content.Load<Texture2D>("Rage");

            skillbox6 = new Sprite(raget, new Vector2(120, 690), new Vector2(100, 100));

            skillboxes.Add(skillbox1);
            skillboxes.Add(skillbox2);
            skillboxes.Add(skillbox3);
            skillboxes.Add(skillbox4);
            skillboxes.Add(skillbox5);
            skillboxes.Add(skillbox6);
            loadTexture = Content.Load<Texture2D>("SKILLBOX");

            eskillbox1 = new Sprite(loadTexture, new Vector2(690, 10), new Vector2(100, 100));
            eskillbox2 = new Sprite(loadTexture, new Vector2(580, 10), new Vector2(100, 100));
            eskillbox3 = new Sprite(loadTexture, new Vector2(690, 120), new Vector2(100, 100));
            eskillbox4 = new Sprite(loadTexture, new Vector2(690, 690), new Vector2(100, 100));
            eskillbox5 = new Sprite(loadTexture, new Vector2(690, 580), new Vector2(100, 100));
            eskillbox6 = new Sprite(loadTexture, new Vector2(580, 690), new Vector2(100, 100));
            skillboxes.Add(eskillbox1);
            skillboxes.Add(eskillbox2);
            skillboxes.Add(eskillbox3);
            skillboxes.Add(eskillbox4);
            skillboxes.Add(eskillbox5);
            skillboxes.Add(eskillbox6);

            healthbar = new HealthBar(loadTexture, user,new Vector2 (10,400));
            enemyhealthbar = new HealthBar(loadTexture, enemy, new Vector2(690, 400));

            enemyattack = new Text(font, "ATK :" + enemy.attack.ToString(), new Vector2(600, 300), Color.White);
            enemydefense = new Text(font, "DEF :" + enemy.defense.ToString(), new Vector2(600, 350), Color.White);
            userattack = new Text(font, "ATK :" + user.attack.ToString(), new Vector2(175, 300), Color.White);
            userdefense = new Text(font, "DEF :" + user.defense.ToString(), new Vector2(175, 350), Color.White);
            enemydodge = new Text(font, "Dodge :" + enemy.dodge.ToString(), new Vector2(600, 250), Color.White);
            userdodge = new Text(font, "Dodge :" + user.dodge.ToString(), new Vector2(175, 250), Color.White);

            door1 = new Sprite(loadTexture, new Vector2(292, 299), new Vector2(25, 50));
            buyingskin2 = new Sprite(loadTexture, new Vector2(100, -600), new Vector2(100, 100));
            buyingskin2display = new Sprite(player2left, new Vector2(100, 50), new Vector2(player2left.Width * 10, player2left.Height * 10));

            buyingskin3 = new Sprite(loadTexture, new Vector2(350, -600), new Vector2(100, 100));
            buyingskin3display = new Sprite(player3left, new Vector2(100, 50), new Vector2(player3left.Width * 10, player3left.Height * 10));

            buyingskin4 = new Sprite(loadTexture, new Vector2(600, -600), new Vector2(100, 100));
            buyingskin4display = new Sprite(player4left, new Vector2(100, 50), new Vector2(player4left.Width * 10, player4left.Height * 10));

            buybutton = new Sprite(loadTexture, new Vector2(600, 600), new Vector2(75, 50));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!battle && !pManager.sign && !pManager.CheckCollisionSkinshop(playerSprite, buyingskin2, buyingskin3, buyingskin4))
            {
                camera.Follow(playerSprite);
                iManager.checkKeyboard(playerSprite);

                foreach (Tree t in treeObjects)
                {
                    pManager.checkCollision(playerSprite, t);
                }
                foreach (Building b in buildings)
                {
                    pManager.checkCollision(playerSprite, b);
                }
               
                battle =  pManager.CheckCollision(playerSprite, hole,user,enemy);
                pManager.CheckCollisionSign(playerSprite, sign1,sign2, sign3);
                bool godoor1 = pManager.CheckCollisionDoor(playerSprite, door1);
                if (godoor1)
                {
                    playerSprite.spritePosition = new Vector2(400, -400);
                }
            }
            else if (battle)
            {
                
                if (Keyboard.GetState().IsKeyDown(Keys.Y))
                {
                    playerSprite.spritePosition = new Vector2(800/2 - playerSprite.spriteSize.X/2, 800/2 - playerSprite.spriteSize.Y/2);
                    battle = false;
                    camera.NoFollow(playerSprite);

                }
                enemyattack.textContent = "ATK :" + enemy.attack.ToString();
                enemydefense.textContent = "DEF :" + enemy.defense.ToString();
                userattack.textContent = "ATK :" + user.attack.ToString();
                userdefense.textContent = "DEF :" + user.defense.ToString();
                enemydodge.textContent = "Dodge :" + enemy.dodge.ToString();
                userdodge.textContent = "Dodge :" + user.dodge.ToString();

                battlesystem.Battling(user, enemy, battle, skillbox1, skillbox2, skillbox3, skillbox4, skillbox5, skillbox6, eskillbox6, eskillbox5, eskillbox4, eskillbox3, eskillbox2, eskillbox1,atkt,mirrort,storet,visiont,dodget,raget,loadTexture);
                

            }
            else if (!battle && pManager.sign && !pManager.CheckCollisionSkinshop(playerSprite, buyingskin2, buyingskin3, buyingskin4))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    pManager.sign = false;
                }

            }
            else if (!battle && !pManager.sign && pManager.CheckCollisionSkinshop(playerSprite, buyingskin2, buyingskin3, buyingskin4))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    pManager.boolean = false;
                }
                if (mManager.CheckClickonSprite(buybutton))
                {
                    pManager.boolean = false;
                    playerSprite.coins -= 100;
                }
                if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Rectangle mrec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
                    Rectangle srec = new Rectangle((int)buybutton.spritePosition.X,(int)buybutton.spritePosition.Y,(int)buybutton.spriteSize.X,(int)buybutton.spriteSize.Y);
                    if (mrec.Intersects(srec))
                    {
                        pManager.boolean = false;
                        playerSprite.coins -= 100;
                    }
                }

            }





            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!battle && !pManager.sign && !pManager.CheckCollisionSkinshop(playerSprite,buyingskin2, buyingskin3, buyingskin4))/////
            {
                GraphicsDevice.Clear(Color.DeepSkyBlue);

                foreach (Tree t in treeObjects)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture,camera);
                }


                foreach (Tree t in hedgeRow1)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }
                foreach (Tree t in hedgeRow2)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }

                foreach (Sprite f in flowerRow)
                {
                    f.DrawSprite(_spriteBatch, f.spriteTexture, camera);
                }


                buyingskin2.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);
                buyingskin3.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);
                buyingskin4.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);

                home1.DrawSprite(_spriteBatch, home1.spriteTexture, camera);
                home2.DrawSprite(_spriteBatch, home2.spriteTexture, camera);
                lab.DrawSprite(_spriteBatch, lab.spriteTexture, camera);
                sign1.DrawSprite(_spriteBatch, sign1.spriteTexture, camera);
                sign2.DrawSprite(_spriteBatch, sign2.spriteTexture, camera);
                sign3.DrawSprite(_spriteBatch, sign3.spriteTexture, camera);
                postbox1.DrawSprite(_spriteBatch, postbox1.spriteTexture, camera);
                postbox2.DrawSprite(_spriteBatch, postbox2.spriteTexture, camera);
                hole.DrawSprite(_spriteBatch, hole.spriteTexture, camera);
                door1.DrawSprite(_spriteBatch, door1.spriteTexture, camera);
                if (playerSprite.moveleft)
                {
                    if (playerSprite.costume == 1)
                    {
                        playerSprite.spriteSize = new Vector2(playerleft.Width, playerleft.Height);
                        playerSprite.DrawSprite(_spriteBatch, playerleft, camera);
                    }
                    else if (playerSprite.costume == 2)
                    {
                        playerSprite.spriteSize = new Vector2(player2left.Width, player2left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player2left, camera);
                    }
                    else if (playerSprite.costume == 3)
                    {
                        playerSprite.spriteSize = new Vector2(player3left.Width, player3left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player3left, camera);
                    }
                    else if (playerSprite.costume == 4)
                    {
                        playerSprite.spriteSize = new Vector2(player4left.Width, player4left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player4left, camera);
                    }
                }
                else if (playerSprite.moveright)
                {
                    if (playerSprite.costume == 1)
                    {
                        playerSprite.spriteSize = new Vector2(playerleft.Width, playerleft.Height);
                        playerSprite.DrawSprite(_spriteBatch, playerright, camera);
                    }
                    else if (playerSprite.costume == 2)
                    {
                        playerSprite.spriteSize = new Vector2(player2left.Width, player2left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player2right, camera);
                    }
                    else if (playerSprite.costume == 3)
                    {
                        playerSprite.spriteSize = new Vector2(player3left.Width, player3left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player3right, camera);
                    }
                    else if (playerSprite.costume == 4)
                    {
                        playerSprite.spriteSize = new Vector2(player4left.Width, player4left.Height);
                        playerSprite.DrawSprite(_spriteBatch, player4right, camera);
                    }
                }


            }
            else if (battle)
            {
                GraphicsDevice.Clear(Color.Black);
                text.DrawText(_spriteBatch);
                enemy.DrawSpriteNoZoom(_spriteBatch, enemy.spriteTexture);
                user.DrawSpriteNoZoom(_spriteBatch, user.spriteTexture);
                foreach (Sprite s in skillboxes)
                {
                    s.DrawSpriteNoZoom(_spriteBatch, s.spriteTexture);
                }
                healthbar.DrawHealth(_spriteBatch,user);
                enemyhealthbar.DrawHealth(_spriteBatch,enemy);
                userattack.DrawText(_spriteBatch);
                enemyattack.DrawText(_spriteBatch);
                userdefense.DrawText(_spriteBatch);
                enemydefense.DrawText(_spriteBatch);
                userdodge.DrawText(_spriteBatch);
                enemydodge.DrawText(_spriteBatch);

            }
            else if ( !battle && pManager.sign && !pManager.CheckCollisionSkinshop(playerSprite, buyingskin2, buyingskin3, buyingskin4))
            {
                foreach (Tree t in treeObjects)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }


                foreach (Tree t in hedgeRow1)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }
                foreach (Tree t in hedgeRow2)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }

                foreach (Sprite f in flowerRow)
                {
                    f.DrawSprite(_spriteBatch, f.spriteTexture, camera);
                }
                buyingskin2.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);
                buyingskin3.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);
                buyingskin4.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);

                home1.DrawSprite(_spriteBatch, home1.spriteTexture, camera);
                home2.DrawSprite(_spriteBatch, home2.spriteTexture, camera);
                lab.DrawSprite(_spriteBatch, lab.spriteTexture, camera);
                sign1.DrawSprite(_spriteBatch, sign1.spriteTexture, camera);
                sign2.DrawSprite(_spriteBatch, sign2.spriteTexture, camera);
                sign3.DrawSprite(_spriteBatch, sign3.spriteTexture, camera);
                postbox1.DrawSprite(_spriteBatch, postbox1.spriteTexture, camera);
                postbox2.DrawSprite(_spriteBatch, postbox2.spriteTexture, camera);
                hole.DrawSprite(_spriteBatch, hole.spriteTexture, camera);

                textbox.DrawSpriteNoZoom(_spriteBatch, textbox.spriteTexture);
                if (pManager.sign1text)
                {
                    sign1text.DrawText(_spriteBatch);
                   
                }
                else if (pManager.sign2text)
                {
                    sign2text.DrawText(_spriteBatch);

                }
                else if (pManager.sign3text)
                {
                    sign3text.DrawText(_spriteBatch);

                }

            }
            else if (!battle && !pManager.sign && pManager.CheckCollisionSkinshop(playerSprite, buyingskin2, buyingskin3, buyingskin4))
            {
                buyingskin2.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);
                buyingskin3.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);

                buyingskin4.DrawSprite(_spriteBatch, buyingskin2.spriteTexture, camera);


                foreach (Tree t in treeObjects)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }


                foreach (Tree t in hedgeRow1)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }
                foreach (Tree t in hedgeRow2)
                {
                    t.DrawSprite(_spriteBatch, t.spriteTexture, camera);
                }

                foreach (Sprite f in flowerRow)
                {
                    f.DrawSprite(_spriteBatch, f.spriteTexture, camera);
                }
                home1.DrawSprite(_spriteBatch, home1.spriteTexture, camera);
                home2.DrawSprite(_spriteBatch, home2.spriteTexture, camera);
                lab.DrawSprite(_spriteBatch, lab.spriteTexture, camera);
                sign1.DrawSprite(_spriteBatch, sign1.spriteTexture, camera);
                sign2.DrawSprite(_spriteBatch, sign2.spriteTexture, camera);
                sign3.DrawSprite(_spriteBatch, sign3.spriteTexture, camera);
                postbox1.DrawSprite(_spriteBatch, postbox1.spriteTexture, camera);
                postbox2.DrawSprite(_spriteBatch, postbox2.spriteTexture, camera);
                hole.DrawSprite(_spriteBatch, hole.spriteTexture, camera);
                buyingskinpage.DrawSpriteNoZoom(_spriteBatch, textbox.spriteTexture);

                if (pManager.skinshopc == 2)
                {
                    buyingskin2display.DrawSpriteNoZoom(_spriteBatch, buyingskin2display.spriteTexture);
                }
                else if (pManager.skinshopc == 3)
                {
                    buyingskin3display.DrawSpriteNoZoom(_spriteBatch, buyingskin3display.spriteTexture);
                }
                else if (pManager.skinshopc == 4)
                {
                    buyingskin4display.DrawSpriteNoZoom(_spriteBatch, buyingskin4display.spriteTexture);
                }
                else
                {
                    buyingskin2display.DrawSpriteNoZoom(_spriteBatch, buyingskin2display.spriteTexture);

                }
                buybutton.DrawSpriteNoZoom(_spriteBatch, buybutton.spriteTexture);
                playercoins.DrawText(_spriteBatch);
            }

            base.Draw(gameTime);
        }


    }
}
