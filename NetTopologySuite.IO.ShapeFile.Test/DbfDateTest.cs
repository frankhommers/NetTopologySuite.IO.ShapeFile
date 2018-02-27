﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetTopologySuite.IO.ShapeFile.Test
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class DbfDateTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalizeTest"/> class.
        /// </summary>
        public DbfDateTest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ReadDbfDate()
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                string.Format("..{0}..{0}..{0}NetTopologySuite.Samples.Shapefiles{0}date.dbf", Path.DirectorySeparatorChar));

            if (!File.Exists(file))
                throw new FileNotFoundException("file not found at " + Path.GetDirectoryName(file));

            DbaseFileReader reader = new DbaseFileReader(file);
            DbaseFileHeader header = reader.GetHeader();
            IEnumerator ienum = reader.GetEnumerator();
            ienum.MoveNext();
            ArrayList items = ienum.Current as ArrayList;

            Assert.IsNotNull(items);
            Assert.AreEqual(2, items.Count);

            foreach (Object item in items)
                Assert.IsNotNull(item);

            DateTime date = (DateTime)items[1];

            Assert.AreEqual(10, date.Day);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(2006, date.Year);
        }
    }
}