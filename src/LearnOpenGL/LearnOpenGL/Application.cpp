#include "Application.h"

void init()
{
	glEnable(GL_DEPTH_TEST);
	//glEnable(GL_CULL_FACE);

	loadModels();
	loadTextures();

	noLightShader = std::make_unique<Shader>("Shaders/no_lighting.vs", "Shaders/no_lighting.fs");
	noLightShader->use();
	noLightShader->setInt("texture0", 0);

	// Uniform buffer objects
	glGenBuffers(1, &uboMatrices);
	glBindBuffer(GL_UNIFORM_BUFFER, uboMatrices);
	glBufferData(GL_UNIFORM_BUFFER, 2 * sizeof(glm::mat4), NULL, GL_STATIC_DRAW);
	glBindBufferBase(GL_UNIFORM_BUFFER, 0, uboMatrices);
	glBindBuffer(GL_UNIFORM_BUFFER, 0);
}

void loop()
{	
	// per-frame time logic
	// --------------------
	float currentFrame = float(glfwGetTime());
	deltaTime = currentFrame - lastFrame;
	lastFrame = currentFrame;

	// input
	// -----
	processInput(window);

	glm::mat4 projection = glm::perspective(glm::radians(camera.Fov), SCR_WIDTH / float(SCR_HEIGHT), 0.1f, 100.f);
	glm::mat4 view = camera.GetViewMatrix();

	glBindBuffer(GL_UNIFORM_BUFFER, uboMatrices);
	glBufferSubData(GL_UNIFORM_BUFFER, 0, sizeof(glm::mat4), &projection);
	glBufferSubData(GL_UNIFORM_BUFFER, sizeof(glm::mat4), sizeof(glm::mat4), glm::value_ptr(view));
	glBindBuffer(GL_UNIFORM_BUFFER, 0);

	// render
    // ------
	glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	drawFloor(noLightShader.get());
	drawCube(noLightShader.get());
}