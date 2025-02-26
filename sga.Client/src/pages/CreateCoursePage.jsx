import { useState } from "react";
import { useNavigate } from "react-router-dom";
import CourseForm from "../components/CourseForm";
import { createCourse } from "../api/CoursesApi";

function CreateCoursePage() {
    const navigate = useNavigate();
    // Estados para mostrar mensajes en pantalla
    const [successMsg, setSuccessMsg] = useState(null);
    const [errorMsg, setErrorMsg] = useState(null);

    const handleCreate = async (newCourse) => {
        // Confirmación antes de crear
        const confirmar = window.confirm(
            `¿Seguro que deseas crear el curso con código "${newCourse.code}"?`
        );
        if (!confirmar) return; // El usuario canceló

        try {
            await createCourse(newCourse);
            // Mensaje de éxito
            setSuccessMsg("¡Curso creado exitosamente!");
            setErrorMsg(null);
            // Opcional: volver tras un breve retraso
            setTimeout(() => {
                navigate("/");
            }, 2000);
        } catch (error) {
            console.error("Error al crear curso", error);
            setErrorMsg("No se pudo crear el curso. Intenta de nuevo.");
            setSuccessMsg(null);
        }
    };

    return (
        <div className="container mt-4">
            <h1 className="mb-4">Crear Curso</h1>

            {/* Alertas de éxito o error */}
            {successMsg && <div className="alert alert-success">{successMsg}</div>}
            {errorMsg && <div className="alert alert-danger">{errorMsg}</div>}

            {/* Formulario para crear curso */}
            <CourseForm
                initialValues={{ code: "", name: "", credits: 0 }}
                onSubmit={handleCreate}
            />
        </div>
    );
}

export default CreateCoursePage;
