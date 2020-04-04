#version 430 core

in vec3 Normal;
in vec3 FragPos;

out vec4 FragColor;

uniform vec3 lightPos;
uniform vec3 eyePos;

uniform vec3 objectColor;
uniform vec3 lightColor;

void main() 
{
	// ambient
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;

	// specular
	float specularStrength = 0.5;
	float shininess = 64;
	vec3 viewDir = normalize(eyePos - FragPos);
	vec3 reflected = reflect(-lightDir, norm);
	float spec = pow(max(dot(reflected, viewDir), 0.0), shininess);
	vec3 specular = lightColor * spec * specularStrength;

            
    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
}