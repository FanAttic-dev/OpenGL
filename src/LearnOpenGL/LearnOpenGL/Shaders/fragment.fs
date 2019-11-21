#version 430 core

in vec2 tex_coord;

uniform	sampler2D box_texture;
uniform	sampler2D face_texture;

out vec4 FragColor;

void main() 
{
	FragColor = mix(texture(box_texture, tex_coord), texture(face_texture, tex_coord), 0.2);
}