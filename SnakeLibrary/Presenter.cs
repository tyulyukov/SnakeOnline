using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeLibrary
{
    public interface IPresentable
    {
        Panel Present();
    }

    public class RoomPresenter : IPresentable
    {
        public EventHandler OnButtonJoinClick; 

        private Room room;

        public RoomPresenter(Room _room)
        {
            room = _room;
        }

        public Panel Present()
        {
            Panel panelRoom = new Panel()
            {
                Dock = DockStyle.Top,
                Width = 527,
                Height = 50,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelName = new Label()
            {
                Text = room.Name,
                Dock = DockStyle.Left,
                Width = 325,
                Font = new Font("Quicksand Medium", 16),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            Label labelPlayers = new Label()
            {
                Text = $"{room.Players.Count}/{room.MaxPlayers}",
                Dock = DockStyle.Left,
                Width = 70,
                Font = new Font("Quicksand Medium", 16),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            Button buttonJoin = new Button()
            {
                Text = "Join",
                Font = new Font("Quicksand", 11.5f),
                Size = new Size(100, 30),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                Tag = room.Id
            };
            buttonJoin.Location = new Point(400, 10);
            if (OnButtonJoinClick != null)
                buttonJoin.Click += OnButtonJoinClick;
            
            panelRoom.Controls.Add(labelPlayers);
            panelRoom.Controls.Add(labelName);
            panelRoom.Controls.Add(buttonJoin);

            return panelRoom;
        }
    }

    public class PlayerPresenter : IPresentable
    {
        public String Nickname { get; private set; } 
        public bool IsCurrentPlayerCreator { get; private set; }

        private EventHandler OnButtonKickClick;
        private bool IsClientCreator;
        private bool IsMe;

        public PlayerPresenter(String nickname, bool isMe, bool isCurrentPlayerCreator, bool isClientCreator, EventHandler buttonKickClick)
        {
            Nickname = nickname;
            IsCurrentPlayerCreator = isCurrentPlayerCreator;
            IsClientCreator = isClientCreator;
            IsMe = isMe;
            OnButtonKickClick = buttonKickClick;
        }

        public Panel Present()
        {
            Panel panelPlayer = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 45,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label labelNickname = new Label()
            {
                Text = Nickname,
                Dock = DockStyle.Left,
                AutoSize = true,
                Font = new Font("Quicksand Medium", 14),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            if (IsMe)
                labelNickname.Text += " <- you";

            if (IsCurrentPlayerCreator)
            {
                labelNickname.ForeColor = Color.Red;
            }
            else if (!IsCurrentPlayerCreator && IsClientCreator)
            {
                Button buttonKick = new Button()
                {
                    Text = "Kick",
                    Font = new Font("Quicksand", 8.5f),
                    Size = new Size(80, 25),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    Location = new Point(297, 8),
                    Tag = Nickname
                };
                buttonKick.Click += OnButtonKickClick;
                panelPlayer.Controls.Add(buttonKick);
            }

            panelPlayer.Controls.Add(labelNickname);

            return panelPlayer;
        }
    }
}
