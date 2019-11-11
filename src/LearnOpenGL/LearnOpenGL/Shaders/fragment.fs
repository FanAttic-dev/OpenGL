#version 430 core

in vec3 our_color;
in vec2 tex_coord;

uniform	sampler2D box_texture;
uniform	sampler2D face_texture;

out vec4 FragColor;

void main() 
{
	//vec4 color = vec4(our_color + 0.5, 1.0);
	FragColor = mix(texture(box_texture, tex_coord), texture(face_texture, tex_coord), 0.2);
}