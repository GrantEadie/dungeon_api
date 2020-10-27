﻿// <auto-generated />
using System;
using DungeonApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DungeonApi.Migrations
{
    [DbContext(typeof(DungeonApiContext))]
    [Migration("20201027224101_Compendium")]
    partial class Compendium
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DungeonApi.Models.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArmorDescription");

                    b.Property<string>("ArmorName");

                    b.Property<string>("ArmorSlot");

                    b.HasKey("ArmorId");

                    b.ToTable("Armor");
                });

            modelBuilder.Entity("DungeonApi.Models.Behavior", b =>
                {
                    b.Property<int>("BehaviorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BehaviorDescription");

                    b.Property<string>("BehaviorName");

                    b.HasKey("BehaviorId");

                    b.ToTable("Behavior");
                });

            modelBuilder.Entity("DungeonApi.Models.ItemProperty", b =>
                {
                    b.Property<int>("ItemPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemPropertyDescription");

                    b.Property<string>("ItemPropertyFlags");

                    b.Property<string>("ItemPropertyName");

                    b.HasKey("ItemPropertyId");

                    b.ToTable("ItemProperty");
                });

            modelBuilder.Entity("DungeonApi.Models.ItemPropertyJoin", b =>
                {
                    b.Property<int>("ItemPropertyJoinId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArmorId");

                    b.Property<int>("ItemPropertyId");

                    b.Property<int?>("WeaponId");

                    b.HasKey("ItemPropertyJoinId");

                    b.HasIndex("ArmorId");

                    b.HasIndex("ItemPropertyId");

                    b.HasIndex("WeaponId");

                    b.ToTable("ItemPropertyJoin");
                });

            modelBuilder.Entity("DungeonApi.Models.MainType", b =>
                {
                    b.Property<int>("MainTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MainTypeDescription");

                    b.Property<string>("MainTypeName");

                    b.HasKey("MainTypeId");

                    b.ToTable("MainType");
                });

            modelBuilder.Entity("DungeonApi.Models.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MonsterName")
                        .IsRequired();

                    b.HasKey("MonsterId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterArmor", b =>
                {
                    b.Property<int>("MonsterArmorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArmorId");

                    b.Property<int>("MonsterId");

                    b.HasKey("MonsterArmorId");

                    b.HasIndex("ArmorId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterArmor");
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterBehavior", b =>
                {
                    b.Property<int>("MonsterBehaviorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BehaviorId");

                    b.Property<int>("MonsterId");

                    b.HasKey("MonsterBehaviorId");

                    b.HasIndex("BehaviorId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterBehavior");
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterMainType", b =>
                {
                    b.Property<int>("MonsterMainTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MainTypeId");

                    b.Property<int>("MonsterId");

                    b.HasKey("MonsterMainTypeId");

                    b.HasIndex("MainTypeId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterMainType");
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterWeapon", b =>
                {
                    b.Property<int>("MonsterWeaponId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MonsterId");

                    b.Property<int>("WeaponId");

                    b.Property<string>("WeaponSlot");

                    b.HasKey("MonsterWeaponId");

                    b.HasIndex("MonsterId");

                    b.HasIndex("WeaponId");

                    b.ToTable("MonsterWeapon");
                });

            modelBuilder.Entity("DungeonApi.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WeaponDescription");

                    b.Property<string>("WeaponName");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("DungeonApi.Models.ItemPropertyJoin", b =>
                {
                    b.HasOne("DungeonApi.Models.Armor", "Armor")
                        .WithMany("ItemProperties")
                        .HasForeignKey("ArmorId");

                    b.HasOne("DungeonApi.Models.ItemProperty", "ItemProperty")
                        .WithMany("ItemPropertyJoins")
                        .HasForeignKey("ItemPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonApi.Models.Weapon", "Weapon")
                        .WithMany("ItemProperties")
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterArmor", b =>
                {
                    b.HasOne("DungeonApi.Models.Armor", "Armor")
                        .WithMany("Monsters")
                        .HasForeignKey("ArmorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonApi.Models.Monster", "Monster")
                        .WithMany("Armors")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterBehavior", b =>
                {
                    b.HasOne("DungeonApi.Models.Behavior", "Behavior")
                        .WithMany("Monsters")
                        .HasForeignKey("BehaviorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonApi.Models.Monster", "Monster")
                        .WithMany("Behaviors")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterMainType", b =>
                {
                    b.HasOne("DungeonApi.Models.MainType", "MainType")
                        .WithMany("Monsters")
                        .HasForeignKey("MainTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonApi.Models.Monster", "Monster")
                        .WithMany("MainTypes")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DungeonApi.Models.MonsterWeapon", b =>
                {
                    b.HasOne("DungeonApi.Models.Monster", "Monster")
                        .WithMany("Weapons")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonApi.Models.Weapon", "Weapon")
                        .WithMany("Monsters")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
