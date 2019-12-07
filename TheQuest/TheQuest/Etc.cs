using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    interface IPotion
    {
        bool Used { get; }
    }

    public void UpdateCharacters()
    {
        Player.Location = game.PlayerLocation;
        playerHitPoints.Text = game.PlayerHitPoints.ToString();

        bool showBat = false;
        bool showGhost = false;
        bool showGhoul = false;
        int enemiesShown = 0;
        //..


        foreach(Enemy enemy in game.Enemies)
        {
            if(enemy is Bat)
            {
                Bat.Location = enemy.Location;
                batHitPoints.Text = enemey.HitPoints.ToString();
                if(enemy.HitPoints > 0)
                {
                    showBat = true;
                    enemiesShown++;
                }
            }

            // ..
        }

        sword.Visible = false;
        bow.Visible = false;
        redPotion.Visible = false;
        bluePotion.Visible = false;
        mace.Visible = false;
        Control weaponControl = null;
        switch(game.WeaponInRoom.Name)
        {
            case "Sword":
                weaponControl = Sword;
                break;

        }


        weaponControl.Location = gameWeaponInRoom.Location;
        if(game.WeaponInRoom.PickedUp)
        {
            weaponControl.Visible = false;
        }
        else
        {
            weaponControl.Visible = true;
        }

        if(Game.PlayerHitPoints <= 0)
        {
            MessageBox.Show("You died");
            Application.Exit();
        }
        if(enemiesShown < 1)
        {
            MessageBox.Show("You have defeated the enemies on this level");
            game.NewLevel(random);
            UpdateCharacters();
        }
    }


}
