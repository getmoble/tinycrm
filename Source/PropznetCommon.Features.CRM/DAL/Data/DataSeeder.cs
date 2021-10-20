using System;
using System.Collections.Generic;
using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using Common.Security;
using Common.Settings.Entities;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.DAL.Data
{
    public class DataSeeder : DropCreateDatabaseIfModelChanges<CRMDataContext>
    {
        protected override void Seed(CRMDataContext context)
        {
            //Common.Data.Seeders.CountrySeeder.Seed(context);
            //context.SaveChanges();

            //var states = new State { CountryId = 228, Name = "Abu dhabi" }; context.States.Add(states); context.SaveChanges();

            //var location1 = new Location { StateId = states.Id, Name = "Abu Dhabi Gate City" }; context.Locations.Add(location1); context.SaveChanges();
            //var location2 = new Location { StateId = states.Id, Name = "Airport Road" }; context.Locations.Add(location2); context.SaveChanges();
            //var location3 = new Location { StateId = states.Id, Name = "Al Ain Industrial Area" }; context.Locations.Add(location3); context.SaveChanges();
            //var location4 = new Location { StateId = states.Id, Name = "Al Aryam" }; context.Locations.Add(location4); context.SaveChanges();
            //var location5 = new Location { StateId = states.Id, Name = "Al Badaa" }; context.Locations.Add(location5); context.SaveChanges();
            //var location6 = new Location { StateId = states.Id, Name = "Al Bahia" }; context.Locations.Add(location6); context.SaveChanges();
            //var location7 = new Location { StateId = states.Id, Name = "Al Baraha" }; context.Locations.Add(location7); context.SaveChanges();
            //var location8 = new Location { StateId = states.Id, Name = "Al Barza" }; context.Locations.Add(location8); context.SaveChanges();
            //var location9 = new Location { StateId = states.Id, Name = "Al Bateen" }; context.Locations.Add(location9); context.SaveChanges();
            //var location10 = new Location { StateId = states.Id, Name = "Al Buraymi" }; context.Locations.Add(location10); context.SaveChanges();
            //var location11 = new Location { StateId = states.Id, Name = "Al Dhafrah" }; context.Locations.Add(location11); context.SaveChanges();
            //var location12 = new Location { StateId = states.Id, Name = "Al Falah City" }; context.Locations.Add(location12); context.SaveChanges();
            //var location13 = new Location { StateId = states.Id, Name = "Al Faqa" }; context.Locations.Add(location13); context.SaveChanges();
            //var location14 = new Location { StateId = states.Id, Name = "Al Ghadeer" }; context.Locations.Add(location14); context.SaveChanges();
            //var location15 = new Location { StateId = states.Id, Name = "Al Hili" }; context.Locations.Add(location15); context.SaveChanges();
            //var location16 = new Location { StateId = states.Id, Name = "Al Hosn" }; context.Locations.Add(location16); context.SaveChanges();
            //var location17 = new Location { StateId = states.Id, Name = "Al Hudayriat Island" }; context.Locations.Add(location17); context.SaveChanges();
            //var location18 = new Location { StateId = states.Id, Name = "Al Ittihad Road" }; context.Locations.Add(location18); context.SaveChanges();
            //var location19 = new Location { StateId = states.Id, Name = "Al Jimi" }; context.Locations.Add(location19); context.SaveChanges();
            //var location20 = new Location { StateId = states.Id, Name = "Al Karamah" }; context.Locations.Add(location20); context.SaveChanges();
            //var location21 = new Location { StateId = states.Id, Name = "Al Khabisi" }; context.Locations.Add(location21); context.SaveChanges();
            //var location22 = new Location { StateId = states.Id, Name = "Al Khaleej Al Arabi Street" }; context.Locations.Add(location22); context.SaveChanges();
            //var location23 = new Location { StateId = states.Id, Name = "Al Khalidiya" }; context.Locations.Add(location23); context.SaveChanges();
            //var location24 = new Location { StateId = states.Id, Name = "Al Maffraq" }; context.Locations.Add(location24); context.SaveChanges();
            //var location25 = new Location { StateId = states.Id, Name = "Al Maha" }; context.Locations.Add(location25); context.SaveChanges();
            //var location26 = new Location { StateId = states.Id, Name = "Al Maharba" }; context.Locations.Add(location26); context.SaveChanges();
            //var location27 = new Location { StateId = states.Id, Name = "Al Manaseer" }; context.Locations.Add(location27); context.SaveChanges();
            //var location28 = new Location { StateId = states.Id, Name = "Al Manhal" }; context.Locations.Add(location28); context.SaveChanges();
            //var location29 = new Location { StateId = states.Id, Name = "Al Maqam" }; context.Locations.Add(location29); context.SaveChanges();
            //var location30 = new Location { StateId = states.Id, Name = "Al Maqtaa" }; context.Locations.Add(location30); context.SaveChanges();
            //var location31 = new Location { StateId = states.Id, Name = "Al Markaz" }; context.Locations.Add(location31); context.SaveChanges();
            //var location32 = new Location { StateId = states.Id, Name = "Al Markaziyah" }; context.Locations.Add(location32); context.SaveChanges();
            //var location33 = new Location { StateId = states.Id, Name = "Al Markhaniya" }; context.Locations.Add(location33); context.SaveChanges();
            //var location34 = new Location { StateId = states.Id, Name = "Al Mina" }; context.Locations.Add(location34); context.SaveChanges();
            //var location35 = new Location { StateId = states.Id, Name = "Al Muneera" }; context.Locations.Add(location35); context.SaveChanges();
            //var location36 = new Location { StateId = states.Id, Name = "Al Mushrif" }; context.Locations.Add(location36); context.SaveChanges();
            //var location37 = new Location { StateId = states.Id, Name = "Al Nadha Abu Dhabi" }; context.Locations.Add(location37); context.SaveChanges();
            //var location38 = new Location { StateId = states.Id, Name = "Al Nahyan" }; context.Locations.Add(location38); context.SaveChanges();
            //var location39 = new Location { StateId = states.Id, Name = "Al Nahyan Camp" }; context.Locations.Add(location39); context.SaveChanges();
            //var location40 = new Location { StateId = states.Id, Name = "Al Najda Street" }; context.Locations.Add(location40); context.SaveChanges();
            //var location41 = new Location { StateId = states.Id, Name = "Al Nasr Street" }; context.Locations.Add(location41); context.SaveChanges();
            //var location42 = new Location { StateId = states.Id, Name = "Al Qurm" }; context.Locations.Add(location42); context.SaveChanges();
            //var location43 = new Location { StateId = states.Id, Name = "Al Raha" }; context.Locations.Add(location43); context.SaveChanges();
            //var location44 = new Location { StateId = states.Id, Name = "Al Raha Beach" }; context.Locations.Add(location44); context.SaveChanges();
            //var location45 = new Location { StateId = states.Id, Name = "Al Raha Gardens" }; context.Locations.Add(location45); context.SaveChanges();
            //var location46 = new Location { StateId = states.Id, Name = "Al Raha Golf Gardens" }; context.Locations.Add(location46); context.SaveChanges();
            //var location47 = new Location { StateId = states.Id, Name = "Al Rahba" }; context.Locations.Add(location47); context.SaveChanges();
            //var location48 = new Location { StateId = states.Id, Name = "Al Rawdah" }; context.Locations.Add(location48); context.SaveChanges();
            //var location49 = new Location { StateId = states.Id, Name = "Al Reef" }; context.Locations.Add(location49); context.SaveChanges();
            //var location50 = new Location { StateId = states.Id, Name = "Al Reef Villas" }; context.Locations.Add(location50); context.SaveChanges();
            //var location51 = new Location { StateId = states.Id, Name = "Al Reem" }; context.Locations.Add(location51); context.SaveChanges();
            //var location52 = new Location { StateId = states.Id, Name = "Al Reem Island" }; context.Locations.Add(location52); context.SaveChanges();
            //var location53 = new Location { StateId = states.Id, Name = "Al Rehhan" }; context.Locations.Add(location53); context.SaveChanges();
            //var location54 = new Location { StateId = states.Id, Name = "Al Ruwais" }; context.Locations.Add(location54); context.SaveChanges();
            //var location55 = new Location { StateId = states.Id, Name = "Al Safarat District" }; context.Locations.Add(location55); context.SaveChanges();
            //var location56 = new Location { StateId = states.Id, Name = "Al Samha" }; context.Locations.Add(location56); context.SaveChanges();
            //var location57 = new Location { StateId = states.Id, Name = "Al Shahama" }; context.Locations.Add(location57); context.SaveChanges();
            //var location58 = new Location { StateId = states.Id, Name = "Al Shamkha" }; context.Locations.Add(location58); context.SaveChanges();
            //var location59 = new Location { StateId = states.Id, Name = "Al Sinaiya" }; context.Locations.Add(location59); context.SaveChanges();
            //var location60 = new Location { StateId = states.Id, Name = "Al Sowwah" }; context.Locations.Add(location60); context.SaveChanges();
            //var location61 = new Location { StateId = states.Id, Name = "Al Tawiya" }; context.Locations.Add(location61); context.SaveChanges();
            //var location62 = new Location { StateId = states.Id, Name = "Al Wadha" }; context.Locations.Add(location62); context.SaveChanges();
            //var location63 = new Location { StateId = states.Id, Name = "Al Wathba" }; context.Locations.Add(location63); context.SaveChanges();
            //var location64 = new Location { StateId = states.Id, Name = "Al Zaab" }; context.Locations.Add(location64); context.SaveChanges();
            //var location65 = new Location { StateId = states.Id, Name = "Arabian Village" }; context.Locations.Add(location65); context.SaveChanges();
            //var location66 = new Location { StateId = states.Id, Name = "Baniyas" }; context.Locations.Add(location66); context.SaveChanges();
            //var location67 = new Location { StateId = states.Id, Name = "Between Two Bridges" }; context.Locations.Add(location67); context.SaveChanges();
            //var location68 = new Location { StateId = states.Id, Name = "Building Materials City" }; context.Locations.Add(location68); context.SaveChanges();
            //var location69 = new Location { StateId = states.Id, Name = "Capital Centre" }; context.Locations.Add(location69); context.SaveChanges();
            //var location70 = new Location { StateId = states.Id, Name = "Capital Plaza" }; context.Locations.Add(location70); context.SaveChanges();
            //var location71 = new Location { StateId = states.Id, Name = "City Downtown" }; context.Locations.Add(location71); context.SaveChanges();
            //var location72 = new Location { StateId = states.Id, Name = "Corniche" }; context.Locations.Add(location72); context.SaveChanges();
            //var location73 = new Location { StateId = states.Id, Name = "Corniche Area" }; context.Locations.Add(location73); context.SaveChanges();
            //var location74 = new Location { StateId = states.Id, Name = "Corniche Road" }; context.Locations.Add(location74); context.SaveChanges();
            //var location75 = new Location { StateId = states.Id, Name = "Danet Abu Dhabi" }; context.Locations.Add(location75); context.SaveChanges();
            //var location76 = new Location { StateId = states.Id, Name = "Defence Street" }; context.Locations.Add(location76); context.SaveChanges();
            //var location77 = new Location { StateId = states.Id, Name = "Delma Street" }; context.Locations.Add(location77); context.SaveChanges();
            //var location78 = new Location { StateId = states.Id, Name = "Desert Village" }; context.Locations.Add(location78); context.SaveChanges();
            //var location79 = new Location { StateId = states.Id, Name = "Eastern Road" }; context.Locations.Add(location79); context.SaveChanges();
            //var location80 = new Location { StateId = states.Id, Name = "Electra Street" }; context.Locations.Add(location80); context.SaveChanges();
            //var location81 = new Location { StateId = states.Id, Name = "Ghantoot" }; context.Locations.Add(location81); context.SaveChanges();
            //var location82 = new Location { StateId = states.Id, Name = "Grand Mosque District" }; context.Locations.Add(location82); context.SaveChanges();
            //var location83 = new Location { StateId = states.Id, Name = "Hamdan Street" }; context.Locations.Add(location83); context.SaveChanges();
            //var location84 = new Location { StateId = states.Id, Name = "Hydra Village" }; context.Locations.Add(location84); context.SaveChanges();
            //var location85 = new Location { StateId = states.Id, Name = "Jawazat Street" }; context.Locations.Add(location85); context.SaveChanges();
            //var location86 = new Location { StateId = states.Id, Name = "Khalidia" }; context.Locations.Add(location86); context.SaveChanges();
            //var location87 = new Location { StateId = states.Id, Name = "Khalifa City (all)" }; context.Locations.Add(location87); context.SaveChanges();
            //var location88 = new Location { StateId = states.Id, Name = "Khalifa City A" }; context.Locations.Add(location88); context.SaveChanges();
            //var location89 = new Location { StateId = states.Id, Name = "Khalifa City B" }; context.Locations.Add(location89); context.SaveChanges();
            //var location90 = new Location { StateId = states.Id, Name = "Khalifa City C" }; context.Locations.Add(location90); context.SaveChanges();
            //var location91 = new Location { StateId = states.Id, Name = "Khalifa Street" }; context.Locations.Add(location91); context.SaveChanges();
            //var location92 = new Location { StateId = states.Id, Name = "Liwa Street" }; context.Locations.Add(location92); context.SaveChanges();
            //var location93 = new Location { StateId = states.Id, Name = "Lulu Island" }; context.Locations.Add(location93); context.SaveChanges();
            //var location94 = new Location { StateId = states.Id, Name = "Madinat Zayed" }; context.Locations.Add(location94); context.SaveChanges();
            //var location95 = new Location { StateId = states.Id, Name = "Marina Village" }; context.Locations.Add(location95); context.SaveChanges();
            //var location96 = new Location { StateId = states.Id, Name = "Masdar City" }; context.Locations.Add(location96); context.SaveChanges();
            //var location97 = new Location { StateId = states.Id, Name = "Mbz" }; context.Locations.Add(location97); context.SaveChanges();
            //var location98 = new Location { StateId = states.Id, Name = "Mohamed Bin Zayed City" }; context.Locations.Add(location98); context.SaveChanges();
            //var location99 = new Location { StateId = states.Id, Name = "Muroor Area" }; context.Locations.Add(location99); context.SaveChanges();
            //var location100 = new Location { StateId = states.Id, Name = "Musaffah Industrial Area" }; context.Locations.Add(location100); context.SaveChanges();
            //var location101 = new Location { StateId = states.Id, Name = "Mushrif" }; context.Locations.Add(location101); context.SaveChanges();
            //var location102 = new Location { StateId = states.Id, Name = "Mussafah" }; context.Locations.Add(location102); context.SaveChanges();
            //var location103 = new Location { StateId = states.Id, Name = "New Khalifa City" }; context.Locations.Add(location103); context.SaveChanges();
            //var location104 = new Location { StateId = states.Id, Name = "Nurai Island" }; context.Locations.Add(location104); context.SaveChanges();
            //var location105 = new Location { StateId = states.Id, Name = "Officers City" }; context.Locations.Add(location105); context.SaveChanges();
            //var location106 = new Location { StateId = states.Id, Name = "Officers Club Area" }; context.Locations.Add(location106); context.SaveChanges();
            //var location107 = new Location { StateId = states.Id, Name = "Saadiyat Island" }; context.Locations.Add(location107); context.SaveChanges();
            //var location108 = new Location { StateId = states.Id, Name = "Salam Street" }; context.Locations.Add(location108); context.SaveChanges();
            //var location109 = new Location { StateId = states.Id, Name = "Sas Al Nakheel" }; context.Locations.Add(location109); context.SaveChanges();
            //var location110 = new Location { StateId = states.Id, Name = "Tawam" }; context.Locations.Add(location110); context.SaveChanges();
            //var location111 = new Location { StateId = states.Id, Name = "Tourist Club Area" }; context.Locations.Add(location111); context.SaveChanges();
            //var location112 = new Location { StateId = states.Id, Name = "World Trade Center" }; context.Locations.Add(location112); context.SaveChanges();
            //var location113 = new Location { StateId = states.Id, Name = "Yas Island" }; context.Locations.Add(location113); context.SaveChanges();
            //var location114 = new Location { StateId = states.Id, Name = "Zakher" }; context.Locations.Add(location114); context.SaveChanges();
            //var location115 = new Location { StateId = states.Id, Name = "Zayed Military City" }; context.Locations.Add(location115); context.SaveChanges();
            //var location116 = new Location { StateId = states.Id, Name = "Zayed Sports City" }; context.Locations.Add(location116); context.SaveChanges();

            //var state1 = new State { CountryId = 228, Name = "Ajman" }; context.States.Add(state1); context.SaveChanges();

            //var location117 = new Location { StateId = state1.Id, Name = "Ain Ajman" }; context.Locations.Add(location117); context.SaveChanges();
            //var location118 = new Location { StateId = state1.Id, Name = "Ajman Boulevard" }; context.Locations.Add(location118); context.SaveChanges();
            //var location119 = new Location { StateId = state1.Id, Name = "Ajman Corniche Road" }; context.Locations.Add(location119); context.SaveChanges();
            //var location120 = new Location { StateId = state1.Id, Name = "Ajman Downtown" }; context.Locations.Add(location120); context.SaveChanges();
            //var location121 = new Location { StateId = state1.Id, Name = "Ajman Industrial Area" }; context.Locations.Add(location121); context.SaveChanges();
            //var location122 = new Location { StateId = state1.Id, Name = "Ajman Marina" }; context.Locations.Add(location122); context.SaveChanges();
            //var location123 = new Location { StateId = state1.Id, Name = "Ajman Meadows" }; context.Locations.Add(location123); context.SaveChanges();
            //var location124 = new Location { StateId = state1.Id, Name = "Ajman Uptown" }; context.Locations.Add(location124); context.SaveChanges();
            //var location125 = new Location { StateId = state1.Id, Name = "Al Ameera Village" }; context.Locations.Add(location125); context.SaveChanges();
            //var location126 = new Location { StateId = state1.Id, Name = "Al Bustan" }; context.Locations.Add(location126); context.SaveChanges();
            //var location127 = new Location { StateId = state1.Id, Name = "Al Humaid City" }; context.Locations.Add(location127); context.SaveChanges();
            //var location128 = new Location { StateId = state1.Id, Name = "Al Ittihad Village" }; context.Locations.Add(location128); context.SaveChanges();
            //var location129 = new Location { StateId = state1.Id, Name = "Al Naemiyah" }; context.Locations.Add(location129); context.SaveChanges();
            //var location130 = new Location { StateId = state1.Id, Name = "Al Rashidiya" }; context.Locations.Add(location130); context.SaveChanges();
            //var location131 = new Location { StateId = state1.Id, Name = "Al Rumaila" }; context.Locations.Add(location131); context.SaveChanges();
            //var location132 = new Location { StateId = state1.Id, Name = "Al Zahraa" }; context.Locations.Add(location132); context.SaveChanges();
            //var location133 = new Location { StateId = state1.Id, Name = "Al Zorah" }; context.Locations.Add(location133); context.SaveChanges();
            //var location134 = new Location { StateId = state1.Id, Name = "Awali City" }; context.Locations.Add(location134); context.SaveChanges();
            //var location135 = new Location { StateId = state1.Id, Name = "Corniche Ajman" }; context.Locations.Add(location135); context.SaveChanges();
            //var location136 = new Location { StateId = state1.Id, Name = "Emirates City" }; context.Locations.Add(location136); context.SaveChanges();
            //var location137 = new Location { StateId = state1.Id, Name = "Garden City" }; context.Locations.Add(location137); context.SaveChanges();
            //var location138 = new Location { StateId = state1.Id, Name = "Green City" }; context.Locations.Add(location138); context.SaveChanges();
            //var location139 = new Location { StateId = state1.Id, Name = "Manama" }; context.Locations.Add(location139); context.SaveChanges();
            //var location140 = new Location { StateId = state1.Id, Name = "Marmooka City" }; context.Locations.Add(location140); context.SaveChanges();
            //var location141 = new Location { StateId = state1.Id, Name = "Muehat" }; context.Locations.Add(location141); context.SaveChanges();
            //var location142 = new Location { StateId = state1.Id, Name = "Musheiref" }; context.Locations.Add(location142); context.SaveChanges();
            //var location143 = new Location { StateId = state1.Id, Name = "New Industrial Area" }; context.Locations.Add(location143); context.SaveChanges();
            //var location144 = new Location { StateId = state1.Id, Name = "Park View City" }; context.Locations.Add(location144); context.SaveChanges();
            //var location145 = new Location { StateId = state1.Id, Name = "Sheikh Khalifa Bin Zayed" }; context.Locations.Add(location145); context.SaveChanges();

            //var state2 = new State { CountryId = 228, Name = "Fujairah" }; context.States.Add(state2); context.SaveChanges();

            //var location146 = new Location { StateId = state2.Id, Name = "Corniche Al Fujairah" }; context.Locations.Add(location146); context.SaveChanges();
            //var location147 = new Location { StateId = state2.Id, Name = "Downtown Fujairah" }; context.Locations.Add(location147); context.SaveChanges();
            //var location148 = new Location { StateId = state2.Id, Name = "Sheikh Hamad Bin  Abdullah St" }; context.Locations.Add(location148); context.SaveChanges();

            //var state3 = new State { CountryId = 228, Name = "Dubai" }; context.States.Add(state3); context.SaveChanges();

            //var location149 = new Location { StateId = state3.Id, Name = "Academic City" }; context.Locations.Add(location149); context.SaveChanges();
            //var location150 = new Location { StateId = state3.Id, Name = "Akoya" }; context.Locations.Add(location150); context.SaveChanges();
            //var location151 = new Location { StateId = state3.Id, Name = "Al Bada'a" }; context.Locations.Add(location151); context.SaveChanges();
            //var location152 = new Location { StateId = state3.Id, Name = "Al Barari" }; context.Locations.Add(location152); context.SaveChanges();
            //var location153 = new Location { StateId = state3.Id, Name = "Al Barsha" }; context.Locations.Add(location153); context.SaveChanges();
            //var location154 = new Location { StateId = state3.Id, Name = "Al Furjan" }; context.Locations.Add(location154); context.SaveChanges();
            //var location155 = new Location { StateId = state3.Id, Name = "Al Garhoud" }; context.Locations.Add(location155); context.SaveChanges();
            //var location156 = new Location { StateId = state3.Id, Name = "Al Hamriya" }; context.Locations.Add(location156); context.SaveChanges();
            //var location157 = new Location { StateId = state3.Id, Name = "Al Jafiliya" }; context.Locations.Add(location157); context.SaveChanges();
            //var location158 = new Location { StateId = state3.Id, Name = "Al Karama" }; context.Locations.Add(location158); context.SaveChanges();
            //var location159 = new Location { StateId = state3.Id, Name = "Al Khail Heights" }; context.Locations.Add(location159); context.SaveChanges();
            //var location160 = new Location { StateId = state3.Id, Name = "Al Khawaneej" }; context.Locations.Add(location160); context.SaveChanges();
            //var location161 = new Location { StateId = state3.Id, Name = "Al Mamzar" }; context.Locations.Add(location161); context.SaveChanges();
            //var location162 = new Location { StateId = state3.Id, Name = "Al Mizhar" }; context.Locations.Add(location162); context.SaveChanges();
            //var location163 = new Location { StateId = state3.Id, Name = "Al Nadha" }; context.Locations.Add(location163); context.SaveChanges();
            //var location164 = new Location { StateId = state3.Id, Name = "Al Quoz" }; context.Locations.Add(location164); context.SaveChanges();
            //var location165 = new Location { StateId = state3.Id, Name = "Al Qusais" }; context.Locations.Add(location165); context.SaveChanges();
            //var location166 = new Location { StateId = state3.Id, Name = "Al Rashidiya" }; context.Locations.Add(location166); context.SaveChanges();
            //var location167 = new Location { StateId = state3.Id, Name = "Al Rigga" }; context.Locations.Add(location167); context.SaveChanges();
            //var location168 = new Location { StateId = state3.Id, Name = "Al Safa" }; context.Locations.Add(location168); context.SaveChanges();
            //var location169 = new Location { StateId = state3.Id, Name = "Al Sufouh" }; context.Locations.Add(location169); context.SaveChanges();
            //var location170 = new Location { StateId = state3.Id, Name = "Al Twar" }; context.Locations.Add(location170); context.SaveChanges();
            //var location171 = new Location { StateId = state3.Id, Name = "Al Warqaa" }; context.Locations.Add(location171); context.SaveChanges();
            //var location172 = new Location { StateId = state3.Id, Name = "Al Warsan" }; context.Locations.Add(location172); context.SaveChanges();
            //var location173 = new Location { StateId = state3.Id, Name = "Al Wasl" }; context.Locations.Add(location173); context.SaveChanges();
            //var location174 = new Location { StateId = state3.Id, Name = "Arabian Ranches" }; context.Locations.Add(location174); context.SaveChanges();
            //var location175 = new Location { StateId = state3.Id, Name = "Bur Dubai" }; context.Locations.Add(location175); context.SaveChanges();
            //var location176 = new Location { StateId = state3.Id, Name = "Business Bay" }; context.Locations.Add(location176); context.SaveChanges();
            //var location177 = new Location { StateId = state3.Id, Name = "Culture Village" }; context.Locations.Add(location177); context.SaveChanges();
            //var location178 = new Location { StateId = state3.Id, Name = "Deira" }; context.Locations.Add(location178); context.SaveChanges();
            //var location179 = new Location { StateId = state3.Id, Name = "DIFC" }; context.Locations.Add(location179); context.SaveChanges();
            //var location180 = new Location { StateId = state3.Id, Name = "Discovery Gardens" }; context.Locations.Add(location180); context.SaveChanges();
            //var location181 = new Location { StateId = state3.Id, Name = "Downtown Burj Dubai" }; context.Locations.Add(location181); context.SaveChanges();
            //var location182 = new Location { StateId = state3.Id, Name = "Downtown Jebel Ali" }; context.Locations.Add(location182); context.SaveChanges();
            //var location183 = new Location { StateId = state3.Id, Name = "Dubai Healthcare City" }; context.Locations.Add(location183); context.SaveChanges();
            //var location184 = new Location { StateId = state3.Id, Name = "Dubai Industrial City" }; context.Locations.Add(location184); context.SaveChanges();
            //var location185 = new Location { StateId = state3.Id, Name = "Dubai Internet City" }; context.Locations.Add(location185); context.SaveChanges();
            //var location186 = new Location { StateId = state3.Id, Name = "Dubai Investment Park" }; context.Locations.Add(location186); context.SaveChanges();
            //var location187 = new Location { StateId = state3.Id, Name = "Dubai Marina" }; context.Locations.Add(location187); context.SaveChanges();
            //var location188 = new Location { StateId = state3.Id, Name = "Dubai Maritime City" }; context.Locations.Add(location188); context.SaveChanges();
            //var location189 = new Location { StateId = state3.Id, Name = "Dubai Media City" }; context.Locations.Add(location189); context.SaveChanges();
            //var location190 = new Location { StateId = state3.Id, Name = "Dubai Studio City" }; context.Locations.Add(location190); context.SaveChanges();
            //var location191 = new Location { StateId = state3.Id, Name = "Dubai Waterfront" }; context.Locations.Add(location191); context.SaveChanges();
            //var location192 = new Location { StateId = state3.Id, Name = "Dubai World Central" }; context.Locations.Add(location192); context.SaveChanges();
            //var location193 = new Location { StateId = state3.Id, Name = "Dubailand" }; context.Locations.Add(location193); context.SaveChanges();
            //var location194 = new Location { StateId = state3.Id, Name = "DuBiotech" }; context.Locations.Add(location194); context.SaveChanges();
            //var location195 = new Location { StateId = state3.Id, Name = "Emirates Golf Course" }; context.Locations.Add(location195); context.SaveChanges();
            //var location196 = new Location { StateId = state3.Id, Name = "Emirates Hills" }; context.Locations.Add(location196); context.SaveChanges();
            //var location197 = new Location { StateId = state3.Id, Name = "Festival City" }; context.Locations.Add(location197); context.SaveChanges();
            //var location198 = new Location { StateId = state3.Id, Name = "Greens" }; context.Locations.Add(location198); context.SaveChanges();
            //var location199 = new Location { StateId = state3.Id, Name = "IMPZ" }; context.Locations.Add(location199); context.SaveChanges();
            //var location200 = new Location { StateId = state3.Id, Name = "International City" }; context.Locations.Add(location200); context.SaveChanges();
            //var location201 = new Location { StateId = state3.Id, Name = "JBR" }; context.Locations.Add(location201); context.SaveChanges();
            //var location202 = new Location { StateId = state3.Id, Name = "Jebel Ali" }; context.Locations.Add(location202); context.SaveChanges();
            //var location203 = new Location { StateId = state3.Id, Name = "Jumeirah" }; context.Locations.Add(location203); context.SaveChanges();
            //var location204 = new Location { StateId = state3.Id, Name = "Jumeirah Golf Estates" }; context.Locations.Add(location204); context.SaveChanges();
            //var location205 = new Location { StateId = state3.Id, Name = "Jumeirah Heights" }; context.Locations.Add(location205); context.SaveChanges();
            //var location206 = new Location { StateId = state3.Id, Name = "Jumeirah Islands" }; context.Locations.Add(location206); context.SaveChanges();
            //var location207 = new Location { StateId = state3.Id, Name = "Jumeirah Lake Towers" }; context.Locations.Add(location207); context.SaveChanges();
            //var location208 = new Location { StateId = state3.Id, Name = "Jumeirah Park" }; context.Locations.Add(location208); context.SaveChanges();
            //var location209 = new Location { StateId = state3.Id, Name = "Jumeirah Village" }; context.Locations.Add(location209); context.SaveChanges();
            //var location210 = new Location { StateId = state3.Id, Name = "Jumeirah Village Triangle" }; context.Locations.Add(location210); context.SaveChanges();
            //var location211 = new Location { StateId = state3.Id, Name = "Lakes" }; context.Locations.Add(location211); context.SaveChanges();
            //var location212 = new Location { StateId = state3.Id, Name = "Majan" }; context.Locations.Add(location212); context.SaveChanges();
            //var location213 = new Location { StateId = state3.Id, Name = "Meadows" }; context.Locations.Add(location213); context.SaveChanges();
            //var location214 = new Location { StateId = state3.Id, Name = "Meydan City" }; context.Locations.Add(location214); context.SaveChanges();
            //var location215 = new Location { StateId = state3.Id, Name = "Mirdiff" }; context.Locations.Add(location215); context.SaveChanges();
            //var location216 = new Location { StateId = state3.Id, Name = "Mohammad Bin Rashid City" }; context.Locations.Add(location216); context.SaveChanges();
            //var location217 = new Location { StateId = state3.Id, Name = "Motor City" }; context.Locations.Add(location217); context.SaveChanges();
            //var location218 = new Location { StateId = state3.Id, Name = "Muhaisnah" }; context.Locations.Add(location218); context.SaveChanges();
            //var location219 = new Location { StateId = state3.Id, Name = "Nad Al Hamar" }; context.Locations.Add(location219); context.SaveChanges();
            //var location220 = new Location { StateId = state3.Id, Name = "Nad Al Sheba" }; context.Locations.Add(location220); context.SaveChanges();
            //var location221 = new Location { StateId = state3.Id, Name = "Old Town" }; context.Locations.Add(location221); context.SaveChanges();
            //var location222 = new Location { StateId = state3.Id, Name = "Other" }; context.Locations.Add(location222); context.SaveChanges();
            //var location223 = new Location { StateId = state3.Id, Name = "Oud Al Muteena" }; context.Locations.Add(location223); context.SaveChanges();
            //var location224 = new Location { StateId = state3.Id, Name = "Palm Jebel Ali" }; context.Locations.Add(location224); context.SaveChanges();
            //var location225 = new Location { StateId = state3.Id, Name = "Palm Jumeirah" }; context.Locations.Add(location225); context.SaveChanges();
            //var location226 = new Location { StateId = state3.Id, Name = "Pearl Jumeirah Island" }; context.Locations.Add(location226); context.SaveChanges();
            //var location227 = new Location { StateId = state3.Id, Name = "Ras Al Khor" }; context.Locations.Add(location227); context.SaveChanges();
            //var location228 = new Location { StateId = state3.Id, Name = "Reem" }; context.Locations.Add(location228); context.SaveChanges();
            //var location229 = new Location { StateId = state3.Id, Name = "Satwa" }; context.Locations.Add(location229); context.SaveChanges();
            //var location230 = new Location { StateId = state3.Id, Name = "Sheikh Zayed Road" }; context.Locations.Add(location230); context.SaveChanges();
            //var location231 = new Location { StateId = state3.Id, Name = "Silicon Oasis" }; context.Locations.Add(location231); context.SaveChanges();
            //var location232 = new Location { StateId = state3.Id, Name = "Sports City" }; context.Locations.Add(location232); context.SaveChanges();
            //var location233 = new Location { StateId = state3.Id, Name = "Springs" }; context.Locations.Add(location233); context.SaveChanges();
            //var location234 = new Location { StateId = state3.Id, Name = "Technology Park" }; context.Locations.Add(location234); context.SaveChanges();
            //var location235 = new Location { StateId = state3.Id, Name = "Techno Park" }; context.Locations.Add(location235); context.SaveChanges();
            //var location236 = new Location { StateId = state3.Id, Name = "TECOM" }; context.Locations.Add(location236); context.SaveChanges();
            //var location237 = new Location { StateId = state3.Id, Name = "The Gardens" }; context.Locations.Add(location237); context.SaveChanges();
            //var location238 = new Location { StateId = state3.Id, Name = "The Hills" }; context.Locations.Add(location238); context.SaveChanges();
            //var location239 = new Location { StateId = state3.Id, Name = "The Lagoons" }; context.Locations.Add(location239); context.SaveChanges();
            //var location240 = new Location { StateId = state3.Id, Name = "The Views" }; context.Locations.Add(location240); context.SaveChanges();
            //var location241 = new Location { StateId = state3.Id, Name = "The World Islands" }; context.Locations.Add(location241); context.SaveChanges();
            //var location242 = new Location { StateId = state3.Id, Name = "Umm Ramool" }; context.Locations.Add(location242); context.SaveChanges();
            //var location243 = new Location { StateId = state3.Id, Name = "Umm Suqueim" }; context.Locations.Add(location243); context.SaveChanges();
            //var location244 = new Location { StateId = state3.Id, Name = "Victory Heights" }; context.Locations.Add(location244); context.SaveChanges();
            //var location245 = new Location { StateId = state3.Id, Name = "World Trade Centre" }; context.Locations.Add(location245); context.SaveChanges();
            //var location246 = new Location { StateId = state3.Id, Name = "Zabeel Road" }; context.Locations.Add(location246); context.SaveChanges();

            //var state4 = new State { CountryId = 228, Name = "Ras al khaimah" }; context.States.Add(state4); context.SaveChanges();

            //var location247 = new Location { StateId = state4.Id, Name = "Al Hamra (all)" }; context.Locations.Add(location247); context.SaveChanges();
            //var location248 = new Location { StateId = state4.Id, Name = "Al Hamra Village" }; context.Locations.Add(location248); context.SaveChanges();
            //var location249 = new Location { StateId = state4.Id, Name = "Al Marjan Island" }; context.Locations.Add(location249); context.SaveChanges();
            //var location250 = new Location { StateId = state4.Id, Name = "Al Qusaidat" }; context.Locations.Add(location250); context.SaveChanges();
            //var location251 = new Location { StateId = state4.Id, Name = "Al Seer" }; context.Locations.Add(location251); context.SaveChanges();
            //var location252 = new Location { StateId = state4.Id, Name = "Bab Al Bahr" }; context.Locations.Add(location252); context.SaveChanges();
            //var location253 = new Location { StateId = state4.Id, Name = "Cornich Ras Al Khaima" }; context.Locations.Add(location253); context.SaveChanges();
            //var location254 = new Location { StateId = state4.Id, Name = "Cove" }; context.Locations.Add(location254); context.SaveChanges();
            //var location255 = new Location { StateId = state4.Id, Name = "Dana Island" }; context.Locations.Add(location255); context.SaveChanges();
            //var location256 = new Location { StateId = state4.Id, Name = "Golf Apartments" }; context.Locations.Add(location256); context.SaveChanges();
            //var location257 = new Location { StateId = state4.Id, Name = "Granada" }; context.Locations.Add(location257); context.SaveChanges();
            //var location258 = new Location { StateId = state4.Id, Name = "Julfar" }; context.Locations.Add(location258); context.SaveChanges();
            //var location259 = new Location { StateId = state4.Id, Name = "Julfar Office" }; context.Locations.Add(location259); context.SaveChanges();
            //var location260 = new Location { StateId = state4.Id, Name = "Julfar Residential" }; context.Locations.Add(location260); context.SaveChanges();
            //var location261 = new Location { StateId = state4.Id, Name = "Luxury B Villa" }; context.Locations.Add(location261); context.SaveChanges();
            //var location262 = new Location { StateId = state4.Id, Name = "Luxury C Villa" }; context.Locations.Add(location262); context.SaveChanges();
            //var location263 = new Location { StateId = state4.Id, Name = "Malibu" }; context.Locations.Add(location263); context.SaveChanges();
            //var location264 = new Location { StateId = state4.Id, Name = "Marina Apartments" }; context.Locations.Add(location264); context.SaveChanges();
            //var location265 = new Location { StateId = state4.Id, Name = "Mina Al Arab" }; context.Locations.Add(location265); context.SaveChanges();
            //var location266 = new Location { StateId = state4.Id, Name = "Oceana Apartments" }; context.Locations.Add(location266); context.SaveChanges();
            //var location267 = new Location { StateId = state4.Id, Name = "RAK Financial City" }; context.Locations.Add(location267); context.SaveChanges();
            //var location268 = new Location { StateId = state4.Id, Name = "RAK Industrial And Technology Park" }; context.Locations.Add(location268); context.SaveChanges();
            //var location269 = new Location { StateId = state4.Id, Name = "Ras Al Khaimah Creek" }; context.Locations.Add(location269); context.SaveChanges();
            //var location270 = new Location { StateId = state4.Id, Name = "Ras Al Khaimah Gateway" }; context.Locations.Add(location270); context.SaveChanges();
            //var location271 = new Location { StateId = state4.Id, Name = "Ras Al Khaimah Waterfront" }; context.Locations.Add(location271); context.SaveChanges();
            //var location272 = new Location { StateId = state4.Id, Name = "Royal Breeze Villas" }; context.Locations.Add(location272); context.SaveChanges();
            //var location273 = new Location { StateId = state4.Id, Name = "Saraya Islands" }; context.Locations.Add(location273); context.SaveChanges();
            //var location274 = new Location { StateId = state4.Id, Name = "Sheik Mohammed Bin Zayed Road" }; context.Locations.Add(location274); context.SaveChanges();
            //var location275 = new Location { StateId = state4.Id, Name = "Yasmin Village" }; context.Locations.Add(location275); context.SaveChanges();

            //var state5 = new State { CountryId = 228, Name = "Sharjah" }; context.States.Add(state5); context.SaveChanges();

            //var location276 = new Location { StateId = state5.Id, Name = "Abu Shagara" }; context.Locations.Add(location276); context.SaveChanges();
            //var location277 = new Location { StateId = state5.Id, Name = "Al Azra" }; context.Locations.Add(location277); context.SaveChanges();
            //var location278 = new Location { StateId = state5.Id, Name = "Al Blaida Area" }; context.Locations.Add(location278); context.SaveChanges();
            //var location279 = new Location { StateId = state5.Id, Name = "Al Brashi" }; context.Locations.Add(location279); context.SaveChanges();
            //var location280 = new Location { StateId = state5.Id, Name = "Al Butina" }; context.Locations.Add(location280); context.SaveChanges();
            //var location281 = new Location { StateId = state5.Id, Name = "Al Ettihad Street" }; context.Locations.Add(location281); context.SaveChanges();
            //var location282 = new Location { StateId = state5.Id, Name = "Al Faisht" }; context.Locations.Add(location282); context.SaveChanges();
            //var location283 = new Location { StateId = state5.Id, Name = "Al Falaj" }; context.Locations.Add(location283); context.SaveChanges();
            //var location284 = new Location { StateId = state5.Id, Name = "Al Ghafeyah Area" }; context.Locations.Add(location284); context.SaveChanges();
            //var location285 = new Location { StateId = state5.Id, Name = "Al Gharayen" }; context.Locations.Add(location285); context.SaveChanges();
            //var location286 = new Location { StateId = state5.Id, Name = "Al Goaz" }; context.Locations.Add(location286); context.SaveChanges();
            //var location287 = new Location { StateId = state5.Id, Name = "Al Jubail" }; context.Locations.Add(location287); context.SaveChanges();
            //var location288 = new Location { StateId = state5.Id, Name = "Al Khaldeia Area" }; context.Locations.Add(location288); context.SaveChanges();
            //var location289 = new Location { StateId = state5.Id, Name = "Al Khan" }; context.Locations.Add(location289); context.SaveChanges();
            //var location290 = new Location { StateId = state5.Id, Name = "Al Khezamia" }; context.Locations.Add(location290); context.SaveChanges();
            //var location291 = new Location { StateId = state5.Id, Name = "Al Majaz" }; context.Locations.Add(location291); context.SaveChanges();
            //var location292 = new Location { StateId = state5.Id, Name = "Al Mamzar - Sharjah" }; context.Locations.Add(location292); context.SaveChanges();
            //var location293 = new Location { StateId = state5.Id, Name = "Al Marejia" }; context.Locations.Add(location293); context.SaveChanges();
            //var location294 = new Location { StateId = state5.Id, Name = "Al Mujarrah" }; context.Locations.Add(location294); context.SaveChanges();
            //var location295 = new Location { StateId = state5.Id, Name = "Al Nadha" }; context.Locations.Add(location295); context.SaveChanges();
            //var location296 = new Location { StateId = state5.Id, Name = "Al Naimiya Area" }; context.Locations.Add(location296); context.SaveChanges();
            //var location297 = new Location { StateId = state5.Id, Name = "Al Nekhailat" }; context.Locations.Add(location297); context.SaveChanges();
            //var location298 = new Location { StateId = state5.Id, Name = "Al Nouf" }; context.Locations.Add(location298); context.SaveChanges();
            //var location299 = new Location { StateId = state5.Id, Name = "Al Nujoom Islands" }; context.Locations.Add(location299); context.SaveChanges();
            //var location300 = new Location { StateId = state5.Id, Name = "Al Qasbaa" }; context.Locations.Add(location300); context.SaveChanges();
            //var location301 = new Location { StateId = state5.Id, Name = "Al Qasemiya" }; context.Locations.Add(location301); context.SaveChanges();
            //var location302 = new Location { StateId = state5.Id, Name = "Al Ramla" }; context.Locations.Add(location302); context.SaveChanges();
            //var location303 = new Location { StateId = state5.Id, Name = "Al Riffa Area" }; context.Locations.Add(location303); context.SaveChanges();
            //var location304 = new Location { StateId = state5.Id, Name = "Al Shahba" }; context.Locations.Add(location304); context.SaveChanges();
            //var location305 = new Location { StateId = state5.Id, Name = "Al Sharq" }; context.Locations.Add(location305); context.SaveChanges();
            //var location306 = new Location { StateId = state5.Id, Name = "Al Taawon" }; context.Locations.Add(location306); context.SaveChanges();
            //var location307 = new Location { StateId = state5.Id, Name = "Al Wadha" }; context.Locations.Add(location307); context.SaveChanges();
            //var location308 = new Location { StateId = state5.Id, Name = "Cornich Al Buhaira" }; context.Locations.Add(location308); context.SaveChanges();
            //var location309 = new Location { StateId = state5.Id, Name = "Halwan" }; context.Locations.Add(location309); context.SaveChanges();
            //var location310 = new Location { StateId = state5.Id, Name = "Hamriyah Free Zone" }; context.Locations.Add(location310); context.SaveChanges();
            //var location311 = new Location { StateId = state5.Id, Name = "Maysaloon" }; context.Locations.Add(location311); context.SaveChanges();
            //var location312 = new Location { StateId = state5.Id, Name = "Muelih" }; context.Locations.Add(location312); context.SaveChanges();
            //var location313 = new Location { StateId = state5.Id, Name = "Rolla Area" }; context.Locations.Add(location313); context.SaveChanges();
            //var location314 = new Location { StateId = state5.Id, Name = "Sharjah Airport Freezone (SAIF)" }; context.Locations.Add(location314); context.SaveChanges();
            //var location315 = new Location { StateId = state5.Id, Name = "Sharjah Industrial Area" }; context.Locations.Add(location315); context.SaveChanges();
            //var location316 = new Location { StateId = state5.Id, Name = "Tilal City" }; context.Locations.Add(location316); context.SaveChanges();
            //var location317 = new Location { StateId = state5.Id, Name = "Umm Khanoor" }; context.Locations.Add(location317); context.SaveChanges();
            //var location318 = new Location { StateId = state5.Id, Name = "Wasit" }; context.Locations.Add(location318); context.SaveChanges();

            //var state6 = new State { CountryId = 228, Name = "Umm al quwain" }; context.States.Add(state6); context.SaveChanges();

            //var location319 = new Location { StateId = state6.Id, Name = "Al Salam City" }; context.Locations.Add(location319); context.SaveChanges();
            //var location320 = new Location { StateId = state6.Id, Name = "Amwaj Resort" }; context.Locations.Add(location320); context.SaveChanges();
            //var location321 = new Location { StateId = state6.Id, Name = "Emirates Modern Industrial" }; context.Locations.Add(location321); context.SaveChanges();
            //var location322 = new Location { StateId = state6.Id, Name = "Khor Al Beidah" }; context.Locations.Add(location322); context.SaveChanges();
            //var location323 = new Location { StateId = state6.Id, Name = "Umm Al Quwain Marina" }; context.Locations.Add(location323); context.SaveChanges();
            //var location324 = new Location { StateId = state6.Id, Name = "White Bay" }; context.Locations.Add(location324); context.SaveChanges();


            //var logoSetting = new Setting { Key = "logo", Value = "logo.png", CreatedOn = DateTime.UtcNow, DefaultValue = "props-logo.png" };
            //context.Settings.Add(logoSetting);
            //context.SaveChanges();

            //var pagingSetting = new Setting { Key = "pagingsize", Value = "20", CreatedOn = DateTime.UtcNow, DefaultValue = "20" };
            //context.Settings.Add(pagingSetting);
            //context.SaveChanges();

            //var propertycategory = new List<PropertyCategory>
            //{
            //   new PropertyCategory{Name = "Apartment"},
            //   new PropertyCategory{Name = "Villa"},
            //   new PropertyCategory{Name = "Office"},
            //   new PropertyCategory{Name = "Retail"},
            //   new PropertyCategory{Name = "Hotel Apartment"},
            //   new PropertyCategory{Name = "Warehouse"},
            //   new PropertyCategory{Name = "Land commercial"},
            //   new PropertyCategory{Name = "Labour Camp"},
            //   new PropertyCategory{Name = "Residential Building"},
            //   new PropertyCategory{Name = "Multiple Sale Units"},
            //   new PropertyCategory{Name = "Land Residential"},
            //   new PropertyCategory{Name = "Commercial Full Building"},
            //   new PropertyCategory{Name = "Penthouse"},
            //   new PropertyCategory{Name = "Duplex"},
            //   new PropertyCategory{Name = "Loft Apartment"},
            //   new PropertyCategory{Name = "Town House"},
            //   new PropertyCategory{Name = "Hotel"},
            //   new PropertyCategory{Name = "Land Mixed use"},
            //   new PropertyCategory{Name = "Compound"},
            //   new PropertyCategory{Name = "Half Floor"},
            //   new PropertyCategory{Name = "Full Floor"},
            //   new PropertyCategory{Name = "Commercial Villa"}
            //};
            //propertycategory.ForEach(s => context.PropertyCategories.Add(s));
            //context.SaveChanges();
            //var salesstage = new List<SalesStage>
            //{
            //   new SalesStage{ Name = "Prospecting",Status=SaleStatus.Prospecting},
            //   new SalesStage{ Name = "Need Analysis",Status=SaleStatus.Prospecting},
            //   new SalesStage{ Name = "Qualified",Status=SaleStatus.Won},
            //   new SalesStage{ Name = "Closed Won",Status=SaleStatus.Won},
            //   new SalesStage{ Name = "Closed Lost ",Status=SaleStatus.Lost},
            //   new SalesStage{ Name = "Quotation",Status=SaleStatus.Prospecting},
            //   new SalesStage{ Name = "Negotiation",Status=SaleStatus.Prospecting}
            //};
            //salesstage.ForEach(s => context.SalesStageMaster.Add(s));
            //context.SaveChanges();
            //var leadsource = new List<LeadSource>
            //{
            //   new LeadSource{ Name = "Agent / Staff"},
            //   new LeadSource{ Name = "Direct Enquiry"},
            //   new LeadSource{ Name = "Website"},
            //   new LeadSource{ Name = "Reference"},
            //   new LeadSource{ Name = "Other "}
            //};
            //leadsource.ForEach(s => context.LeadSourceMaster.Add(s));
            //context.SaveChanges();
            //var leadstatus = new List<LeadStatus>
            //{
            //   new LeadStatus{ Name = "New"},
            //   new LeadStatus{ Name = "Contacted"},
            //   new LeadStatus{ Name = "Contacted - Follow up required"},
            //   new LeadStatus{ Name = "Contact in Future"},
            //   new LeadStatus{ Name = "Cold"},
            //   new LeadStatus{ Name = "Hot"},
            //   new LeadStatus{ Name = "Dead"}
            //};
            //leadstatus.ForEach(s => context.LeadStatusMaster.Add(s));
            //context.SaveChanges();
            //var communicationdetail = new List<CRMCommunicationDetail>
            //{
            //   new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="wilfred@gmail.com", Phone="9658741236",Website="www.wilfred.com"},
            //   new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="john@gmail.com", Phone="9658741236",Website="www.abycorp.com"},
            //   new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="smithjohn@gmail.com", Phone="9658741236",Website="www.focus.com"},
            //   new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="burke@gmail.com", Phone="9658741236",Website="www.extend.com"}
            //};
            //communicationdetail.ForEach(s => context.CRMCommunicationDetails.Add(s));
            //context.SaveChanges();


            ////user
            //var newAdminAccessRule = AccessRule.CreateNewUserAccessRule(true);
            //context.AccessRules.Add(newAdminAccessRule);
            //context.SaveChanges();

            //var newUserAccessRule = AccessRule.CreateNewUserAccessRule(true);
            //context.AccessRules.Add(newUserAccessRule);
            //context.SaveChanges();

            //var adminRole = new Role { Name = "Admin" };
            //context.Roles.Add(adminRole);
            //context.SaveChanges();

            //var userRole = new Role { Name = "User" };
            //context.Roles.Add(userRole);
            //context.SaveChanges();


            //var person = new Person { FirstName = "Admin", LastName = "Logiticks", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            //context.Persons.Add(person);
            //context.SaveChanges();

            //var newPerson = new Person { FirstName = "User", LastName = "Logiticks", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            //context.Persons.Add(newPerson);
            //context.SaveChanges();


            //var admin = new User { Username = "admin@logiticks.com", Name = "Admin", Password = HashHelper.Hash("admin"), PersonId = person.Id, AccessRuleId = newAdminAccessRule.Id };
            //context.Users.Add(admin);
            //context.SaveChanges();

            //var newuser = new User { Username = "user@logiticks.com", Name = "User", Password = HashHelper.Hash("user"), PersonId = newPerson.Id, AccessRuleId = newUserAccessRule.Id, CreatedByUserId = admin.Id };
            //context.Users.Add(newuser);
            //context.SaveChanges();

            //var accountViewPermission = new RolePermission
            //{
            //    PermissionCode = 100,
            //    Title = "ViewAccount",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(accountViewPermission);
            //context.SaveChanges();

            //var accountAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 100,
            //    Title = "ViewAccount",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(accountAdminViewPermission);
            //context.SaveChanges();

            //var accountManagePermission = new RolePermission
            //{
            //    PermissionCode = 101,
            //    Title = "ManageAccount",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(accountManagePermission);
            //context.SaveChanges();


            //var leadViewPermission = new RolePermission
            //{
            //    PermissionCode = 102,
            //    Title = "ViewLead",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(leadViewPermission);
            //context.SaveChanges();

            //var leadAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 102,
            //    Title = "ViewLead",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(leadAdminViewPermission);
            //context.SaveChanges();

            //var leadManagePermission = new RolePermission
            //{
            //    PermissionCode = 103,
            //    Title = "ManageLead",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(leadManagePermission);
            //context.SaveChanges();

            //var contactViewPermission = new RolePermission
            //{
            //    PermissionCode = 104,
            //    Title = "ViewContact",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(contactViewPermission);
            //context.SaveChanges();

            //var contactAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 104,
            //    Title = "ViewContact",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(contactAdminViewPermission);
            //context.SaveChanges();

            //var contactManagePermission = new RolePermission
            //{
            //    PermissionCode = 105,
            //    Title = "ManageContact",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(contactManagePermission);
            //context.SaveChanges();

            //var potentialViewPermission = new RolePermission
            //{
            //    PermissionCode = 106,
            //    Title = "ViewPotential",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(potentialViewPermission);
            //context.SaveChanges();

            //var potentialAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 106,
            //    Title = "ViewPotential",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(potentialAdminViewPermission);
            //context.SaveChanges();

            //var potentialManagePermission = new RolePermission
            //{
            //    PermissionCode = 107,
            //    Title = "ManagePotential",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(potentialManagePermission);
            //context.SaveChanges();


            //var agentViewPermission = new RolePermission
            //{
            //    PermissionCode = 108,
            //    Title = "ViewAgent",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(agentViewPermission);
            //context.SaveChanges();

            //var agentAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 108,
            //    Title = "ViewAgent",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(agentAdminViewPermission);
            //context.SaveChanges();

            //var agentManagePermission = new RolePermission
            //{
            //    PermissionCode = 109,
            //    Title = "ManageAgent",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(agentManagePermission);
            //context.SaveChanges();

            //var convertLeadPermission = new RolePermission
            //{
            //    PermissionCode = 110,
            //    Title = "convertLead",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(convertLeadPermission);
            //context.SaveChanges();

            //var settingsPermission = new RolePermission
            //{
            //    PermissionCode = 111,
            //    Title = "settings",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(settingsPermission);
            //context.SaveChanges();

            //var dashBoardPermission = new RolePermission
            //{
            //    PermissionCode = 112,
            //    Title = "dashboard",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(dashBoardPermission);
            //context.SaveChanges();

            //var adminRoleMember = new RoleMember
            //{
            //    RoleId = adminRole.Id,
            //    UserId = admin.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow,
            //};
            //context.RoleMembers.Add(adminRoleMember);
            //context.SaveChanges();

            //var userRoleMember = new RoleMember
            //{
            //    RoleId = userRole.Id,
            //    UserId = newuser.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow,
            //};
            //context.RoleMembers.Add(userRoleMember);
            //context.SaveChanges();


            //var adminAgent = new Agent { CommunicationDetailId = 1, DEDLicenseNumber = "D7878778", FirstName = "Admin", Image = "Person-Dummy.jpg", IsListingMember = true, LastName = "Shastri", RERARegistrationNumber = "R6446464", RefId = "A01", UserId = 1 };
            //context.Agents.Add(adminAgent);
            //context.SaveChanges();

            //var userAgent = new Agent { CommunicationDetailId = 1, DEDLicenseNumber = "D7845578", FirstName = "Anu", Image = "Person-Dummy.jpg", IsListingMember = true, LastName = "Sharma", RERARegistrationNumber = "R6422264", RefId = "A02", UserId = 2 };
            //context.Agents.Add(userAgent);
            //context.SaveChanges();

            //var agent = new List<Agent>
            //{
            //   //new Agent{ CommunicationDetailId=1,DEDLicenseNumber="D7878778",FirstName="Admin",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Shastri",RERARegistrationNumber="R6446464",RefId="Admin"},
            //   new Agent{ CommunicationDetailId=2,DEDLicenseNumber="D7323778",FirstName="Piya",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Sharma",RERARegistrationNumber="R6333364",RefId="A03",CreatedBy=1},
            //   new Agent{ CommunicationDetailId=1,DEDLicenseNumber="D7890908",FirstName="Lakshmi",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Anuj",RERARegistrationNumber="R6447777",RefId="A04",CreatedBy=1},
            //   new Agent{ CommunicationDetailId=3,DEDLicenseNumber="D7123228",FirstName="Ajmal",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Amal",RERARegistrationNumber="R6448888",RefId="A05",CreatedBy=1},
            //   new Agent{ CommunicationDetailId=3,DEDLicenseNumber="D7333278",FirstName="Divyanka",Image="Person-Dummy.jpg",IsListingMember=true,LastName="A K",RERARegistrationNumber="R6987654",RefId="A06",CreatedBy=1},
            //   new Agent{ CommunicationDetailId=1,DEDLicenseNumber="D7675678",FirstName="Reenu",Image="Person-Dummy.jpg",IsListingMember=true,LastName="M P",RERARegistrationNumber="R6445678",RefId="A07",CreatedBy=1}
            //};
            //agent.ForEach(s => context.Agents.Add(s));
            //context.SaveChanges();
            //var lead = new List<Lead>
            //{
            //    new Lead{AgentId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L01",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=5,RefId="L02",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L03",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L04",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=1,RefId="L05",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L06",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L07",CreatedBy=2,UpdatedBy=2},
            //    new Lead{AgentId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=1,RefId="L08",CreatedBy=2,UpdatedBy=2},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L09",CreatedBy=2,UpdatedBy=2},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=4,RefId="L10",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=4,RefId="L11",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=6,RefId="L12",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=6,RefId="L13",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=7,RefId="L14",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=7,RefId="L15",CreatedBy=1,UpdatedBy=1},
            //    new Lead{AgentId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=6,RefId="L16",CreatedBy=1,UpdatedBy=1}
            //};
            //lead.ForEach(s => context.Leads.Add(s));
            //context.SaveChanges();
            //var property = new List<CRMProperty>
            //{
            //    new CRMProperty{Area=1200,BudgetFrom=1000,BudgetTo=20000,Floor=2,LocationId=2,PropertyCategoryId=3,PropertyType=CRMPropertyType.Rent,RefId="P01",StateId=3,CreatedBy=1,UpdatedBy=1},
            //    new CRMProperty{Area=1200,BudgetFrom=1000,BudgetTo=20000,Floor=1,LocationId=3,PropertyCategoryId=2,PropertyType=CRMPropertyType.Rent,RefId="P02",StateId=1,CreatedBy=1,UpdatedBy=1},
            //    new CRMProperty{Area=1200,BudgetFrom=1000,BudgetTo=20000,Floor=0,LocationId=4,PropertyCategoryId=3,PropertyType=CRMPropertyType.Rent,RefId="P03",StateId=3,CreatedBy=2,UpdatedBy=2}
            //};
            //property.ForEach(s => context.CRMProperties.Add(s));
            //context.SaveChanges();
            //var account = new List<Account>
            //{
            //    new Account{AgentId=1,Comments="no comments",CommunicationDetailId=1,Industry="Private",Name="Ac123",RefId="AT01",CreatedBy=1,UpdatedBy=1},
            //    new Account{AgentId=2,Comments="no comments",CommunicationDetailId=2,Industry="Private",Name="Ac103",RefId="AT02",CreatedBy=1,UpdatedBy=1},
            //    new Account{AgentId=3,Comments="no comments",CommunicationDetailId=3,Industry="Private",Name="Ac113",RefId="AT03",CreatedBy=2,UpdatedBy=2}
            //};
            //account.ForEach(s => context.Accounts.Add(s));
            //context.SaveChanges();
            //var contact = new List<Contact>
            //{
            //    new Contact{AccountId=1,AgentId=1,CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",RefId="C01",Title="New contact",CreatedBy=1,UpdatedBy=1},
            //    new Contact{AccountId=2,AgentId=2,CommunicationDetailId=2,FirstName="Anju",LastName="Raj",RefId="C02",Title="New contact",CreatedBy=2,UpdatedBy=2},
            //    new Contact{AccountId=3,AgentId=3,CommunicationDetailId=3,FirstName="Anna",LastName="Jose",RefId="C03",Title="New contact",CreatedBy=1,UpdatedBy=1}
            //};
            //contact.ForEach(s => context.Contacts.Add(s));
            //context.SaveChanges();
            //var potential = new List<Potential>
            //{
            //    new Potential{AccountId=1,AgentId=1,Comments="no comments",ContactId=1,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=3,Name="P3433",PropertyId=1,RefId="Po01",SalesStageId=4,CreatedBy=2,UpdatedBy=2,UpdatedOn=Convert.ToDateTime("5/5/2015")},
            //    new Potential{AccountId=2,AgentId=2,Comments="no comments",ContactId=2,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=2,Name="P2433",PropertyId=2,RefId="Po02",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/5/2015")},
            //    new Potential{AccountId=3,AgentId=3,Comments="no comments",ContactId=3,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=1,Name="P4433",PropertyId=3,RefId="Po03",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/5/2015")},
            //    new Potential{AccountId=1,AgentId=1,Comments="no comments",ContactId=1,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=3,Name="P3433",PropertyId=1,RefId="Po04",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/6/2015")},
            //    new Potential{AccountId=2,AgentId=2,Comments="no comments",ContactId=2,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=2,Name="P2433",PropertyId=2,RefId="Po05",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/6/2015")},
            //    new Potential{AccountId=3,AgentId=3,Comments="no comments",ContactId=3,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=1,Name="P4433",PropertyId=3,RefId="Po06",SalesStageId=4,CreatedBy=2,UpdatedBy=2,UpdatedOn=Convert.ToDateTime("5/6/2015")},
            //    new Potential{AccountId=1,AgentId=1,Comments="no comments",ContactId=1,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=3,Name="P3433",PropertyId=1,RefId="Po07",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/7/2015")},
            //    new Potential{AccountId=2,AgentId=2,Comments="no comments",ContactId=2,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=2,Name="P2433",PropertyId=2,RefId="Po08",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/7/2015")},
            //    new Potential{AccountId=3,AgentId=3,Comments="no comments",ContactId=3,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=1,Name="P4433",PropertyId=3,RefId="Po09",SalesStageId=4,CreatedBy=2,UpdatedBy=2,UpdatedOn=Convert.ToDateTime("5/7/2015")},
            //    new Potential{AccountId=1,AgentId=1,Comments="no comments",ContactId=1,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=3,Name="P3433",PropertyId=1,RefId="Po10",SalesStageId=4,CreatedBy=2,UpdatedBy=2,UpdatedOn=Convert.ToDateTime("5/8/2015")},
            //    new Potential{AccountId=2,AgentId=2,Comments="no comments",ContactId=2,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=2,Name="P2433",PropertyId=2,RefId="Po11",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/8/2015")},
            //    new Potential{AccountId=3,AgentId=3,Comments="no comments",ContactId=3,ExpectedAmount=12000,ExpectedCloseDate=Convert.ToDateTime("5/5/2015"),LeadSourceId=1,Name="P4433",PropertyId=3,RefId="Po12",SalesStageId=4,CreatedBy=1,UpdatedBy=1,UpdatedOn=Convert.ToDateTime("5/8/2015")}
            //};
            //potential.ForEach(s => context.Potentials.Add(s));
            //context.SaveChanges();
            //var toDos = new List<CRMToDo>
            //{
            //    new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
            //    new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
            //    new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")},
            //    new CRMToDo{StartDate=Convert.ToDateTime("1/6/2015"),EndDate=Convert.ToDateTime("1/6/2015"),DueDate=Convert.ToDateTime("1/6/2015"),IsRecurring=true,Title="New Work",CreatedBy=1,Time=Convert.ToDateTime("5:00")}
            //};
            //toDos.ForEach(s => context.CRMToDos.Add(s));
            //context.SaveChanges();
            //var toDoMaps = new List<CRMToDoMap>
            //{
            //    new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Lead,CreatedBy=1},
            //    new CRMToDoMap{ToDoId=2,EntityType=CRMEntityType.Lead,CreatedBy=1},
            //    new CRMToDoMap{ToDoId=3,EntityType=CRMEntityType.Lead,CreatedBy=2},
            //    new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=1},
            //    new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=1},
            //    new CRMToDoMap{ToDoId=1,EntityType=CRMEntityType.Account,CreatedBy=2}
            //};
            //toDoMaps.ForEach(s => context.CRMToDoMaps.Add(s));
            //context.SaveChanges();
        }
    }
}
