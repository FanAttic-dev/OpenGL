#version 430 core

layout (location = 0) in vec3 aPos;

layout(std140, binding = 0) uniform Matrices
{
	// base alignment	// offset
	mat4 projection;	// 4 * 16 = 64		// 0
	mat4 view;			// 4 * 16 = 64		// 64
};

out vec3 TexCoords;

void main() 
{
	TexCoords = aPos;
	gl_Position = projection * view * vec4(aPos, 1.0);
}