﻿using System.Collections.Generic;
using System.Xml.Serialization;
using GenArt.Classes;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GenArt.AST
{
    [Serializable]
    public class DnaDrawing
    {
        public List<DnaPolygon> Polygons { get; set; }

        [XmlIgnore]
        public bool IsDirty { get; private set; }

        public int PointCount
        {
            get
            {
                int pointCount = 0;
                foreach (DnaPolygon polygon in Polygons)
                    pointCount += polygon.Points.Count;

                return pointCount;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDirty()
        {
            IsDirty = true;
        }

        public void Init()
        {
            Polygons = new List<DnaPolygon>();

            for (int i = 0; i < Settings.ActivePolygonsMin; i++)
                AddPolygon();

            SetDirty();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DnaDrawing Clone()
        {
            var drawing = new DnaDrawing();
            drawing.Polygons = new List<DnaPolygon>();
            foreach (DnaPolygon polygon in Polygons)
                drawing.Polygons.Add(polygon.Clone());

            return drawing;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Mutate()
        {
            if (Tools.WillMutate(Settings.ActiveAddPolygonMutationRate))
                AddPolygon();

            if (Tools.WillMutate(Settings.ActiveRemovePolygonMutationRate))
                RemovePolygon();

            if (Tools.WillMutate(Settings.ActiveMovePolygonMutationRate))
                MovePolygon();

            foreach (DnaPolygon polygon in Polygons)
                polygon.Mutate(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MovePolygon()
        {
            if (Polygons.Count < 1)
                return;

            int index = Tools.GetRandomNumber(0, Polygons.Count);
            DnaPolygon poly = Polygons[index];
            Polygons.RemoveAt(index);
            index = Tools.GetRandomNumber(0, Polygons.Count);
            Polygons.Insert(index, poly);
            SetDirty();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemovePolygon()
        {
            if (Polygons.Count > Settings.ActivePolygonsMin)
            {
                int index = Tools.GetRandomNumber(0, Polygons.Count);
                Polygons.RemoveAt(index);
                SetDirty();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddPolygon()
        {
            if (Polygons.Count < Settings.ActivePolygonsMax)
            {
                var newPolygon = new DnaPolygon();
                newPolygon.Init();

                int index = Tools.GetRandomNumber(0, Polygons.Count);

                Polygons.Insert(index, newPolygon);
                SetDirty();
            }
        }
    }
}