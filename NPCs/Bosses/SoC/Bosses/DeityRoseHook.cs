using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace AAMod.NPCs.Bosses.SoC.Bosses
{
    /*public class DeityRoseHook: ModNPC
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ei'Lor's Claw");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.width = 40;
            npc.height = 40;
            npc.aiStyle = -1;
            npc.damage = 60;
            npc.defense = 24;
            npc.lifeMax = 4000;
            npc.dontTakeDamage = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            bool flag48 = false;
            bool flag49 = false;
            if (AAModGlobalNPC.Rose < 0)
            {
                npc.StrikeNPCNoInteraction(9999, 0f, 0, false, false, false);
                npc.netUpdate = true;
                return;
            }
            if (Main.player[Main.npc[AAModGlobalNPC.Rose].target].dead)
            {
                flag49 = true;
            }
            if ((AAModGlobalNPC.Rose != -1 && !Main.player[Main.npc[AAModGlobalNPC.Rose].target].ZoneBeach) || (double)Main.player[Main.npc[AAModGlobalNPC.Rose].target].position.Y < Main.worldSurface * 16.0 || Main.player[Main.npc[AAModGlobalNPC.Rose].target].position.Y > (float)((Main.maxTilesY - 200) * 16) || flag49)
            {
                npc.localAI[0] -= 4f;
                flag48 = true;
            }
            if (Main.netMode == 1)
            {
                if (npc.ai[0] == 0f)
                {
                    npc.ai[0] = (float)((int)(npc.Center.X / 16f));
                }
                if (npc.ai[1] == 0f)
                {
                    npc.ai[1] = (float)((int)(npc.Center.X / 16f));
                }
            }
            if (Main.netMode != 1)
            {
                if (npc.ai[0] == 0f || npc.ai[1] == 0f)
                {
                    npc.localAI[0] = 0f;
                }
                npc.localAI[0] -= 1f;
                if (Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 2)
                {
                    npc.localAI[0] -= 2f;
                }
                if (Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 4)
                {
                    npc.localAI[0] -= 2f;
                }
                if (flag48)
                {
                    npc.localAI[0] -= 6f;
                }
                if (!flag49 && npc.localAI[0] <= 0f && npc.ai[0] != 0f)
                {
                    for (int num735 = 0; num735 < 200; num735++)
                    {
                        if (num735 != npc.whoAmI && Main.npc[num735].active && Main.npc[num735].type == npc.type && (Main.npc[num735].velocity.X != 0f || Main.npc[num735].velocity.Y != 0f))
                        {
                            npc.localAI[0] = (float)Main.rand.Next(60, 300);
                        }
                    }
                }
                if (npc.localAI[0] <= 0f)
                {
                    npc.localAI[0] = (float)Main.rand.Next(300, 600);
                    bool flag50 = false;
                    int num736 = 0;
                    while (!flag50 && num736 <= 1000)
                    {
                        num736++;
                        int num737 = (int)(Main.player[Main.npc[AAModGlobalNPC.Rose].target].Center.X / 16f);
                        int num738 = (int)(Main.player[Main.npc[AAModGlobalNPC.Rose].target].Center.Y / 16f);
                        if (npc.ai[0] == 0f)
                        {
                            num737 = (int)((Main.player[Main.npc[AAModGlobalNPC.Rose].target].Center.X + Main.npc[AAModGlobalNPC.Rose].Center.X) / 32f);
                            num738 = (int)((Main.player[Main.npc[AAModGlobalNPC.Rose].target].Center.Y + Main.npc[AAModGlobalNPC.Rose].Center.Y) / 32f);
                        }
                        if (flag49)
                        {
                            num737 = (int)Main.npc[AAModGlobalNPC.Rose].position.X / 16;
                            num738 = (int)(Main.npc[AAModGlobalNPC.Rose].position.Y + 400f) / 16;
                        }
                        int num739 = 20;
                        num739 += (int)(100f * ((float)num736 / 1000f));
                        int num740 = num737 + Main.rand.Next(-num739, num739 + 1);
                        int num741 = num738 + Main.rand.Next(-num739, num739 + 1);
                        if (Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 2 && Main.rand.Next(6) == 0)
                        {
                            npc.TargetClosest(true);
                            int num742 = (int)(Main.player[npc.target].Center.X / 16f);
                            int num743 = (int)(Main.player[npc.target].Center.Y / 16f);
                            if (Main.tile[num742, num743].wall > 0)
                            {
                                num740 = num742;
                                num741 = num743;
                            }
                        }
                        try
                        {
                            if (WorldGen.SolidTile(num740, num741) || (Main.tile[num740, num741].wall > 0 && (num736 > 500 || Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 2)))
                            {
                                flag50 = true;
                                npc.ai[0] = (float)num740;
                                npc.ai[1] = (float)num741;
                                npc.netUpdate = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (npc.ai[0] > 0f && npc.ai[1] > 0f)
            {
                float num744 = 6f;
                if (Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 2)
                {
                    num744 = 8f;
                }
                if (Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 4)
                {
                    num744 = 10f;
                }
                if (Main.expertMode)
                {
                    num744 += 1f;
                }
                if (Main.expertMode && Main.npc[AAModGlobalNPC.Rose].life < Main.npc[AAModGlobalNPC.Rose].lifeMax / 2)
                {
                    num744 += 1f;
                }
                if (flag48)
                {
                    num744 *= 2f;
                }
                if (flag49)
                {
                    num744 *= 2f;
                }
                Vector2 vector91 = new Vector2(npc.Center.X, npc.Center.Y);
                float num745 = npc.ai[0] * 16f - 8f - vector91.X;
                float num746 = npc.ai[1] * 16f - 8f - vector91.Y;
                float num747 = (float)Math.Sqrt((double)(num745 * num745 + num746 * num746));
                if (num747 < 12f + num744)
                {
                    npc.velocity.X = num745;
                    npc.velocity.Y = num746;
                }
                else
                {
                    num747 = num744 / num747;
                    npc.velocity.X = num745 * num747;
                    npc.velocity.Y = num746 * num747;
                }
                Vector2 vector92 = new Vector2(npc.Center.X, npc.Center.Y);
                float num748 = Main.npc[AAModGlobalNPC.Rose].Center.X - vector92.X;
                float num749 = Main.npc[AAModGlobalNPC.Rose].Center.Y - vector92.Y;
                npc.rotation = (float)Math.Atan2((double)num749, (double)num748) - 1.57f;
            }
        }

        public override void HitEffect(int hitDirection, double dmg)
        {
            if (npc.life > 0)
            {
                int num440 = 0;
                while ((double)num440 < dmg / (double)npc.lifeMax * 100.0)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.CthulhuDust>(), (float)hitDirection, -1f, 0, default(Color), 1f);
                    
                    num440++;
                }
                return;
            }
            for (int num441 = 0; num441 < 150; num441++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.CthulhuDust>(), (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
                
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)Main.screenPosition.X - 800, (int)Main.screenPosition.Y - 800, Main.screenWidth + 1600, Main.screenHeight + 1600);
            for (int i = 199; i >= 0; i--)
            {
                try
                {
                    if (Main.npc[i].active && Main.npc[i].type > 0 && Main.npc[i].type < 580 && !Main.npc[i].hide)
                    {
                        Main.npc[i].visualOffset *= 0.95f;
                        Main.npc[i].position += Main.npc[i].visualOffset;
                        if (Main.npc[i].behindTiles == npc.behindTiles)
                        {
                            if (AAModGlobalNPC.Rose >= 0)
                            {
                                Vector2 vector2 = new Vector2(Main.npc[i].position.X + (float)(Main.npc[i].width / 2), Main.npc[i].position.Y + (float)(Main.npc[i].height / 2));
                                float num6 = Main.npc[NPC.plantBoss].Center.X - vector2.X;
                                float num7 = Main.npc[NPC.plantBoss].Center.Y - vector2.Y;
                                float rotation2 = (float)Math.Atan2((double)num7, (double)num6) - 1.57f;
                                bool flag3 = true;
                                while (flag3)
                                {
                                    int num8 = 16;
                                    int num9 = 32;
                                    float num10 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
                                    if (num10 < (float)num9)
                                    {
                                        num8 = (int)num10 - num9 + num8;
                                        flag3 = false;
                                    }
                                    num10 = (float)num8 / num10;
                                    num6 *= num10;
                                    num7 *= num10;
                                    vector2.X += num6;
                                    vector2.Y += num7;
                                    num6 = Main.npc[NPC.plantBoss].Center.X - vector2.X;
                                    num7 = Main.npc[NPC.plantBoss].Center.Y - vector2.Y;
                                    Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
                                    Main.spriteBatch.Draw(mod.GetTexture("NPCs/Bosses/SoC/Bosses/DeityRoseHook_Chain"), new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, Main.chain26Texture.Width, num8)), color2, rotation2, new Vector2((float)Main.chain26Texture.Width * 0.5f, (float)Main.chain26Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Main.npc[i].active = false;
                }
            }
            return true;
        }
    }*/
}