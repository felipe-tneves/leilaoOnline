﻿using LeilaoOnline;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeiLaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert 
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
            );
        }
    }
}
