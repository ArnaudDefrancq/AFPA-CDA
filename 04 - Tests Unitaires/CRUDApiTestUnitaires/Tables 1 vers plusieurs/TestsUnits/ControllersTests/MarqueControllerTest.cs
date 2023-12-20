using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tables_1_vers_plusieurs.Controllers;
using Tables_1_vers_plusieurs.Interfaces;
using Tables_1_vers_plusieurs.Models.Data;
using Tables_1_vers_plusieurs.Models.Dtos;

namespace TestsUnits.ControllersTests
{
	public class MarqueControllerTest
	{
		Marque marque;
		List<Marque> listMarque = new List<Marque>();
		int goodId;
		int badId;
		IMapper mapper;
		Mock<MarqueServiceInterface> service;
		MarqueController controller;

		[SetUp]
		public void Setup()
		{
			marque = new Marque() { IdMarque = 1, Libelle = "marque" };
			listMarque = new List<Marque>() { marque, new Marque() { IdMarque = 2, Libelle = "marque" }, new Marque() { IdMarque = 3, Libelle = "marque" } };
			badId = 999;
			goodId = 1;
			mapper = new Mock<IMapper>().Object;
			service = new Mock<MarqueServiceInterface>();
			controller = new MarqueController(service.Object, mapper);
		}

		[Test]
		public void GetMarqueById_Test_IdExist()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(goodId)).Returns(marque);

			// init du controller
			var getMarque = controller.GetMarqueById(goodId);

			// On check la sortie
			Assert.IsNotNull(getMarque); // Check que getMarque pas null
			Assert.IsInstanceOf<ActionResult<MarqueDtoAvecModeles>>(getMarque); // On check que l'objet de sortie est bien MarqueDtoAvecModel
		}

		[Test]
		public void GetMarqueById_Test_IdNotExist()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(badId)).Returns((Marque)null);

			// init du controller
			var getMarque = controller.GetMarqueById(goodId);

			// On check la sortie
			Assert.IsNull(getMarque.Value); // Check que getMarque est null
			Assert.IsInstanceOf<NotFoundResult>(getMarque.Result);// On check que la fonction return NotFound
		}

		[Test]
		public void GetAllMarques_Test_Found()
		{
			// Init du service
			service.Setup(s => s.GetAllMarques()).Returns(listMarque);

			// init du controller
			var getMarque = controller.GetAllMarque();

			// On check la sortie
			Assert.IsNotNull(getMarque); // Check que getMarque pas null
			Assert.IsInstanceOf<ActionResult<IEnumerable<MarqueDtoAvecModeles>>>(getMarque); // On check que l'objet de sortie est bien MarqueDtoAvecModel
		}

		[Test]
		public void GetAllMarques_Test_NotFound()
		{
			// Init du service
			service.Setup(s => s.GetAllMarques()).Returns((IEnumerable<Marque>)null);

			// init du controller
			var getMarque = controller.GetAllMarque();

			// On check la sortie
			Assert.IsNull(getMarque.Value); // Check que getMarque pas null
			Assert.IsInstanceOf<NotFoundResult>(getMarque.Result);// On check que la fonction return NotFound
		}

		[Test]
		public void CreateMarque_Test_WithGoodObject()
		{
			// Init du service
			service.Setup(s => s.AddMarque(marque));

			// Creation du Dto pour le create
			MarqueDtoSansModeles marqueDtoSansModeles = new MarqueDtoSansModeles() { IdMarque = 1, Libelle = "marque" };

			// init du controller
			var getMarque = controller.CreateMarque(marqueDtoSansModeles);

			// On check la sortie
			Assert.IsNotNull(getMarque); // Check que getMarque pas null
			Assert.IsInstanceOf<ActionResult<MarqueDtoSansModeles>>(getMarque); // On check que l'objet de sortie est bien MarqueDtoAvecModel
		}

		[Test]
		public void CreateMarque_Test_WithBadObject()
		{
			// Init du service
			service.Setup(s => s.AddMarque((Marque)null)).Throws<ArgumentNullException>();

			// Creation du Dto pour le create
			MarqueDtoSansModeles marqueDtoSansModeles = null;

			// init du controller
			var getMarque = controller.CreateMarque(marqueDtoSansModeles);

			// On check la sortie
			Assert.IsNotNull(getMarque);
			Assert.IsInstanceOf<BadRequestResult>(getMarque.Result);  // On check que la fonction return BadRequest
		}

		[Test]
		public void UpdateMarque_Test_GoodId()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(goodId)).Returns(marque);
			service.Setup(s => s.UpdateMarque(marque));

			// Creation du Dto pour le create
			MarqueDtoSansModeles marqueDtoSansModeles = new MarqueDtoSansModeles() { IdMarque = 1, Libelle = "marque" };

			// init du controller
			var getMarque = controller.UpdateMarque(goodId, marqueDtoSansModeles);

			// On check la sortie
			Assert.IsNotNull(getMarque); // Check que getMarque pas null
			Assert.IsInstanceOf<NoContentResult>(getMarque);
		}
		[Test]
		public void UpdateMarque_Test_BadId()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(badId)).Returns((Marque)null);
			var test = service.Setup(s => s.UpdateMarque((Marque)null)).Throws<ArgumentNullException>();

			// Creation du Dto pour le create
			MarqueDtoSansModeles marqueDtoSansModeles = new MarqueDtoSansModeles() { IdMarque = 1, Libelle = "marque" };

			// init du controller
			var getMarque = controller.UpdateMarque(badId, marqueDtoSansModeles);

			// On check la sortie
			Assert.IsNotNull(getMarque); // Check que getMarque pas null
			Assert.IsInstanceOf<NotFoundResult>(getMarque);
		}
		[Test]
		public void DeleteMarque_Test_GoodId()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(goodId)).Returns(marque);
			service.Setup(s => s.DeleteMarque(marque));

			// init du controller
			var getController = controller.DeleteMarque(goodId);

			// On check la sortie
			Assert.IsNotNull(getController);
			Assert.IsInstanceOf<NoContentResult>(getController);


		}
		[Test]
		public void DeleteMarque_Test_BadId()
		{
			// Init du service
			service.Setup(s => s.GetMarqueById(badId)).Returns((Marque)null);
			service.Setup(s => s.DeleteMarque((Marque)null)).Throws<ArgumentNullException>();

			// init controller
			var getController = controller.DeleteMarque(badId);

			// Check sortie
			Assert.IsNotNull(getController);
			Assert.IsInstanceOf<NotFoundResult>(getController);

		}

	}
}
