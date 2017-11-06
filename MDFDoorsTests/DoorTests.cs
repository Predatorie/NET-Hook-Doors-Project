// <copyright file="DoorTests.cs" company="Mick George @Osoy">
// Copyright (c) Mick George @Osoy. All rights reserved.
// </copyright>

namespace MDFDoors.Tests
{
    using System.Linq;
    using Factories;
    using Shared;
    using Shared.Factories;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Module.Views;

    [TestClass]
    public class DoorTests
    {
        #region Private Fields

        /// <summary>The container.</summary>
        private UnityContainer container;

        /// <summary>The view factory.</summary>
        private ViewFactory viewFactory;

        /// <summary>The parameters factory.</summary>
        private NavigationParametersFactory parametersFactory;

        #endregion

        #region Initialization

        /// <summary>Initializes this object.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestInitialize]
        public void Initialize()
        {
            this.container = new UnityContainer();
            this.viewFactory = new ViewFactory(this.container);
            this.parametersFactory = new NavigationParametersFactory();
        }

        #endregion

        #region Tests

        /// <summary>(Unit Test Method) request shaker ellegance returns shaker ellegence.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_ShakerElegance_Returns_ShakerElegence()
        {
            var view = this.viewFactory.View(DoorStyles.ShakerElegance);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(ShakerEleganceView));
        }

        /// <summary>(Unit Test Method) request shaker exotic returns shaker exotic.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_ShakerExotic_Returns_ShakerExotic()
        {
            var view = this.viewFactory.View(DoorStyles.ShakerExotic);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(Module.Views.ShakerExoticView));
        }

        /// <summary>(Unit Test Method) request shaker returns shaker.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_Shaker_Returns_Shaker()
        {
            var view = this.viewFactory.View(DoorStyles.Shaker);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(Module.Views.ShakerView));
        }

        /// <summary>(Unit Test Method) request shaker country returns shaker country.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_ShakerCountry_Returns_ShakerCountry()
        {
            var view = this.viewFactory.View(DoorStyles.ShakerCountry);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(Module.Views.ShakerCountryView));
        }

        /// <summary>(Unit Test Method) request shaker euro 05 returns shaker euro 05.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_ShakerEuro05_Returns_ShakerEuro05()
        {
            var view = this.viewFactory.View(DoorStyles.ShakerEuro05);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(ShakerEuro05View));
        }

        /// <summary>(Unit Test Method) request shaker finest returns shaker finest.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Request_ShakerFinest_Returns_ShakerFinest()
        {
            var view = this.viewFactory.View(DoorStyles.ShakerFinest);

            Assert.IsTrue(view.IsSuccess);
            Assert.IsInstanceOfType(view.Value, typeof(ShakerFinestView));
        }

        /// <summary>(Unit Test Method) request shaker title returns shaker title.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_Shaker_Returns_Shaker_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.Shaker);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.Shaker));
        }

        /// <summary>(Unit Test Method) creates shaker elegance returns shaker elegance navigation
        /// parameters.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_ShakerElegance_Returns_ShakerElegance_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.ShakerElegance);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.ShakerElegance));
        }

        /// <summary>(Unit Test Method) creates shaker country returns shaker country navigation
        /// parameters.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_ShakerCountry_Returns_ShakerCountry_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.ShakerCountry);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.ShakerCountry));
        }

        /// <summary>(Unit Test Method) creates shaker euro 05 returns shaker euro 05 navigation
        /// parameters.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_ShakerEuro05_Returns_ShakerEuro05_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.ShakerEuro05);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.ShakerEuro05));
        }

        /// <summary>(Unit Test Method) creates shaker finest returns shaker finest navigation
        /// parameters.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_ShakerFinest_Returns_ShakerFinest_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.ShakerFinest);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.ShakerFinest));
        }

        /// <summary>(Unit Test Method) creates shaker exotic returns shaker exotic navigation
        /// parameters.</summary>
        ///
        /// <remarks>Mick George, 11/4/2017.</remarks>
        [TestMethod]
        public void Create_ShakerExotic_Returns_ShakerExotic_NavigationParams()
        {
            var navigationParameters = this.parametersFactory.Create(DoorStyles.ShakerExotic);

            Assert.IsTrue(navigationParameters.Count() == 3);
            Assert.IsInstanceOfType(navigationParameters[NavigationParamIndexer.Style], typeof(DoorStyles));
            Assert.IsTrue(ReferenceEquals(navigationParameters[NavigationParamIndexer.Name], DoorNames.Exotic));
        }

        #endregion
    }
}
