﻿namespace AutoSteal.Champs
{
    using EloBuddy;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Menu.Values;
    using System.Linq;

    class Thresh
    {

        public static Spell.Skillshot Q { get; set; }
        public static Spell.Skillshot E { get; set; }
        public static Menu ThreshMenu { get; set; }

        public static void KS()
        {
            foreach (AIHeroClient target in
                ObjectManager.Get<AIHeroClient>()
                    .Where(
                        hero =>
                        hero.IsValidTarget(Q.Range)
                        && !hero.HasBuffOfType(BuffType.Invulnerability)
                        && hero.IsEnemy
                        && !hero.IsDead
                        && !hero.IsZombie))
            {
                if (ThreshMenu["QC"].Cast<CheckBox>().CurrentValue)
                {
                    if (Player.GetSpell(SpellSlot.Q).Name == "ThreshQ" && ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(target, SpellSlot.Q) > Check.HealthPrediction.GetHealthPrediction(target, (int)(E.CastDelay * 1000))
                        && Q.IsInRange(target) && Q.IsReady())
                    {
                        var pred = Q.GetPrediction(target);
                        Q.Cast(pred.CastPosition);
                        return;
                    }
                }
                if (ThreshMenu["EC"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(target, SpellSlot.E) > Check.HealthPrediction.GetHealthPrediction(target, (int)(E.CastDelay * 1000))
                        && E.IsInRange(target) && E.IsReady())
                    {
                        var pred = E.GetPrediction(target);
                        E.Cast(pred.CastPosition);
                        return;
                    }
                }
            }
        }

        public static void JKS()
        {
            foreach (Obj_AI_Minion mob in
                ObjectManager.Get<Obj_AI_Minion>()
                    .Where(
                        jmob =>
                        jmob.IsValidTarget(Q.Range)
                        && !jmob.HasBuffOfType(BuffType.Invulnerability)
                        && jmob.IsMonster
                        && !jmob.IsDead
                        && !jmob.IsZombie
                        && (jmob.BaseSkinName == "SRU_Dragon"
                        || jmob.BaseSkinName == "SRU_Baron"
                        || jmob.BaseSkinName == "SRU_Gromp"
                        || jmob.BaseSkinName == "SRU_Krug"
                        || jmob.BaseSkinName == "SRU_Razorbeak"
                        || jmob.BaseSkinName == "Sru_Crab"
                        || jmob.BaseSkinName == "SRU_Murkwolf"
                        || jmob.BaseSkinName == "SRU_Blue"
                        || jmob.BaseSkinName == "SRU_Red")))
            {
                if (ThreshMenu["QJ"].Cast<CheckBox>().CurrentValue)
                {
                    if (Player.GetSpell(SpellSlot.Q).Name == "ThreshQ" && ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(mob, SpellSlot.Q) > Check.HealthPrediction.GetHealthPrediction(mob, (int)(Q.CastDelay * 1000))
                        && Q.IsInRange(mob))
                    {
                        Q.Cast(mob.Position);
                        return;
                    }
                }

                if (ThreshMenu["EJ"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.BaseAbilityDamage + ObjectManager.Player.GetSpellDamage(mob, SpellSlot.E) > Check.HealthPrediction.GetHealthPrediction(mob, (int)(E.CastDelay * 1000))
                        && E.IsInRange(mob))
                    {
                        E.Cast(mob.Position);
                        return;
                    }
                }
            }
        }
    }
}
