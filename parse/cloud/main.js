Parse.Cloud.define('sendPassword', function(request, response) {

	var Mandrill = require('mandrill');
	Mandrill.initialize('fw-s2MzO1K3KG1gl9E4tWQ');

	Mandrill.sendEmail({
	  message: {		
		subject: "Bienvenido a Aventura Matematica!",
		html: "Hola " + request.params.username + ", tu password para ingresar al juego es: " +  request.params.password,
		from_email: "no-reply@tipitap.com",
		from_name: "Aventura Matematica",
		to: [
		  {
			email: request.params.to,
			name: request.params.username
		  }
		]
	  },
	  async: true
	},{
	  success: function(httpResponse) {
		console.log(httpResponse);
		response.success("Email sent!");
	  },
	  error: function(httpResponse) {
		console.error(httpResponse);
		response.error("Uh oh, something went wrong");
	  }
	});


});