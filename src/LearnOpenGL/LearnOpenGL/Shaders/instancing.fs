#version 430 core
out vec4 FragColor;

in vec2 TexCoords;
in vec2 offset;

uniform sampler2D texture0;


void main()
{
	//FragColor = texture(texture0, TexCoords);
	FragColor = vec4(offset.xy, 0.5, 1.0);
}