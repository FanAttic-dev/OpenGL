#version 430 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aCol;
layout (location = 2) in vec2 aTexCoord;

uniform mat4 trans;

out vec3 our_color;
out vec2 tex_coord;

void main()
{
	our_color = aPos;

	tex_coord = aTexCoord;
    gl_Position = trans * vec4(aPos, 1.0);
}