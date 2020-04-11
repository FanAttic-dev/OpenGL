#version 430 core
out vec4 FragColor;

in vec2 TexCoords;

uniform bool inversion;
uniform sampler2D screenTexture;

void main()
{
	if (inversion) 
	{
		FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
	} 
	else
	{
		vec4 color = texture(screenTexture, TexCoords);
		float average = 0.2126 * color.r + 0.7152 * color.g + 0.0722 * color.b;
		FragColor = vec4(vec3(average), 1.0);
	}
}