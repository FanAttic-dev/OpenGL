#version 430 core

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec3 aNormal;
layout(location = 2) in vec2 aTexCoords;

out vec3 FragPos;
out vec3 Normal;
out vec2 TexCoords;

layout(std140, binding = 0) uniform Matrices
{
	// base alignment	// offset
	mat4 projection;	// 4 * 16 = 64		// 0
	mat4 view;			// 4 * 16 = 64		// 64
};

uniform mat4 model;

void main()
{
	FragPos = vec3(model * vec4(aPos, 1.0));
	Normal = mat3(inverse(transpose(model))) * aNormal;
	TexCoords = aTexCoords;

	gl_Position = projection * view * vec4(FragPos, 1.0);
}