#version 430 core
out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform sampler2D texture0;

void main()
{
	//FragColor = texture(texture0, TexCoords);
	FragColor = vec4(vec3(0.5), 1.0);
}