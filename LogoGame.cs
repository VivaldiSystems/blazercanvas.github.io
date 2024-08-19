using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using BlazorCanvas.Example5.Core;
using BlazorCanvas.Example5.Core.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorCanvas.Example5
{




    public class LogoGame : GameContext
    {
        private Canvas2DContext _context;
        private GameObject _blazorLogo;
        
        private const int _logoWidth = 200;
        private const int _logoHeight = 200;



        public int positionx = 0;

        private LogoGame()
        {

            ResetColor();




        }

        private void ResetColor()
        {
            Globals.clickcolor1 = "Magenta";
            Globals.clickcolor2 = "orange";
            Globals.clickcolor3 = "green";

            Globals.clickcolor4 = "blue";
            Globals.clickcolor5 = "Purple";
            Globals.clickcolor6 = "pink";

            Globals.clickcolor7 = "brown";
            Globals.clickcolor8 = "Teal";
            Globals.clickcolor9 = "gray";
        }

        public static async ValueTask<LogoGame> Create(BECanvasComponent canvas, ElementReference spritesheet)
        {
            var blazorLogo = new GameObject();
            blazorLogo.Components.Add(new Transform(blazorLogo)
            {
                Position = Vector2.Zero,
                Direction = Vector2.One,
                Size = new Size(_logoWidth, _logoHeight),
            });

            var sprite = new Sprite()
            {
                Size = new Size(_logoWidth, _logoHeight),
                SpriteSheet = spritesheet
            };
            blazorLogo.Components.Add(new SpriteRenderComponent(sprite, blazorLogo));

            blazorLogo.Components.Add(new LogoBrain(blazorLogo));

            var game = new LogoGame {_context = await canvas.CreateCanvas2DAsync(), _blazorLogo = blazorLogo};

            return game;
        }

        protected override async ValueTask Update()
        {
            await _blazorLogo.Update(this);
        }

        protected override async ValueTask Render()
        {

            if (Globals.CurrentMouseX >= 100 && Globals.CurrentMouseY >= 200 && Globals.CurrentMouseX <= 180 && Globals.CurrentMouseY <= 280)
            {

                Globals.clickcolor1 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 200 && Globals.CurrentMouseY >= 200 && Globals.CurrentMouseX <= 280 && Globals.CurrentMouseY <= 280)
            {

                Globals.clickcolor2 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 300 && Globals.CurrentMouseY >= 200 && Globals.CurrentMouseX <= 380 && Globals.CurrentMouseY <= 280)
            {

                Globals.clickcolor3 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 100 && Globals.CurrentMouseY >= 300 && Globals.CurrentMouseX <= 180 && Globals.CurrentMouseY <= 380)
            {

                Globals.clickcolor4 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 200 && Globals.CurrentMouseY >= 300 && Globals.CurrentMouseX <= 280 && Globals.CurrentMouseY <= 380)
            {

                Globals.clickcolor5 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 300 && Globals.CurrentMouseY >= 300 && Globals.CurrentMouseX <= 380 && Globals.CurrentMouseY <= 380)
            {

                Globals.clickcolor6 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 100 && Globals.CurrentMouseY >= 400 && Globals.CurrentMouseX <= 180 && Globals.CurrentMouseY <= 480)
            {

                Globals.clickcolor7 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 200 && Globals.CurrentMouseY >= 400 && Globals.CurrentMouseX <= 280 && Globals.CurrentMouseY <= 480)
            {

                Globals.clickcolor8 = "black";
                Globals.lastresult = "Correct";
            }
            else if (Globals.CurrentMouseX >= 300 && Globals.CurrentMouseY >= 400 && Globals.CurrentMouseX <= 380 && Globals.CurrentMouseY <= 480)
            {

                Globals.clickcolor9 = "black";
                Globals.lastresult = "Correct";
            }

            await _context.ClearRectAsync(0, 0, this.Display.Size.Width, this.Display.Size.Height);

            await _context.SetStrokeStyleAsync("white");

            await _context.SetFontAsync("bold 24px verdana");

            await _context.StrokeTextAsync("Blocks Game V1.1", 20, 40);

            await _context.StrokeTextAsync(Globals.CurrentMouseX.ToString() +" - "+ Globals.CurrentMouseX.ToString() + "  Result: " + Globals.lastresult, 450, 40);

            //var spriteRenderer = _blazorLogo.Components.Get<SpriteRenderComponent>();
            //await spriteRenderer.Render(_context);

            //blue Box  answers
            await _context.SetFontAsync("28px verdana");
            await _context.SetStrokeStyleAsync("white");



            await _context.SetFillStyleAsync(Globals.clickcolor1);
            await _context.FillRectAsync(100, 200, 80, 80);
            await _context.StrokeTextAsync($"24", 120, 240);


            await _context.SetFillStyleAsync(Globals.clickcolor2);
            await _context.FillRectAsync(200, 200, 80, 80);
            await _context.StrokeTextAsync($"32", 220, 240);

            await _context.SetFillStyleAsync(Globals.clickcolor3);
            await _context.FillRectAsync(300, 200, 80, 80);
            await _context.StrokeTextAsync($"12", 320, 240);


            //second row
            await _context.SetFillStyleAsync(Globals.clickcolor4);
            await _context.FillRectAsync(100, 300, 80, 80);
            await _context.StrokeTextAsync($"24", 120, 340);


            await _context.SetFillStyleAsync(Globals.clickcolor5);
            await _context.FillRectAsync(200,300, 80, 80);
            await _context.StrokeTextAsync($"32", 220, 340);

            await _context.SetFillStyleAsync(Globals.clickcolor6);
            await _context.FillRectAsync(300, 300, 80, 80);
            await _context.StrokeTextAsync($"12", 320, 340);

            //3rd row
            await _context.SetFillStyleAsync(Globals.clickcolor7);
            await _context.FillRectAsync(100, 400, 80, 80);
            await _context.StrokeTextAsync($"24", 120, 440);


            await _context.SetFillStyleAsync(Globals.clickcolor8);
            await _context.FillRectAsync(200, 400, 80, 80);
            await _context.StrokeTextAsync($"32", 220, 440);

            await _context.SetFillStyleAsync(Globals.clickcolor9);
            await _context.FillRectAsync(300, 400, 80, 80);
            await _context.StrokeTextAsync($"12", 320, 440);


            await _context.SetFillStyleAsync("yellow");

            positionx++;

            if (positionx > 750)
            {
                positionx = 400;
            }

            await _context.SetStrokeStyleAsync("black");
            await _context.FillRectAsync(positionx, 200, 200, 80);
            await _context.StrokeTextAsync($"6 + 6", positionx + 30, 240);



        }
    }
}