DevManager System
Sistema de gestión ágil de proyectos de software desarrollado en C# utilizando:
•	Git
•	GitHub
•	Pull Requests
•	GitHub Actions
•	DevOps
•	Trabajo colaborativo
•	Relaciones de clases
________________________________________
1. IDEA GENERAL DEL PROYECTO
La empresa necesita organizar el desarrollo de software porque presenta:
•	pérdida de versiones
•	desorganización
•	errores frecuentes
•	mala comunicación
•	falta de automatización
La solución será un sistema desarrollado en C# que permita:
•	gestionar proyectos
•	gestionar tareas
•	gestionar desarrolladores
•	controlar estados
•	organizar trabajo colaborativo
Además se implementará:
•	control de versiones con Git
•	repositorio GitHub
•	ramas
•	Pull Requests
•	GitHub Actions
•	CI/CD
3. ESTRUCTURA DEL PROYECTO
DevManager/
│
├── Clases/
│   ├── Persona.cs
│   ├── Empleado.cs
│   ├── Desarrollador.cs
│   ├── Tester.cs
│   ├── Proyecto.cs
│   ├── Tarea.cs
│   ├── Empresa.cs
│   └── ReporteService.cs
│
├── Formularios/
│   ├── FrmLogin.cs
│   ├── FrmMenu.cs
│   ├── FrmProyecto.cs
│   ├── FrmTareas.cs
│   ├── FrmEmpleados.cs
│   └── FrmReportes.cs
│
├── .github/
│   └── workflows/
│       └── dotnet.yml
│
└── Program.cs
________________________________________
