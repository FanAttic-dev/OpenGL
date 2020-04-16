#version 430 core

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec2 aTexCoords;

layout(std140, binding = 0) uniform Matrices
{
	// base alignment	// offset
	mat4 projection;	// 4 * 16 = 64		// 0
	mat4 view;			// 4 * 16 = 64		// 64
};

uniform mat4 model;
uniform vec2 offsets[100];

out vec2 TexCoords;
out vec2 offset;

void main()
{
	offset = offsets[gl_InstanceID];
	vec4 pos = model * vec4(aPos.xy, 0.0, 1.0);
	gl_Position = vec4(pos.xy + offset, 0.0, 1.0);
	TexCoords = aTexCoords;
}