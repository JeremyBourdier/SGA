import { useState } from "react";
import PropTypes from "prop-types";

function CourseForm({ initialValues, onSubmit }) {
    const [formData, setFormData] = useState(initialValues);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(formData);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-3">
                <label className="form-label">Código:</label>
                <input
                    type="text"
                    name="code"
                    className="form-control"
                    value={formData.code}
                    onChange={handleChange}
                />
            </div>

            <div className="mb-3">
                <label className="form-label">Nombre:</label>
                <input
                    type="text"
                    name="name"
                    className="form-control"
                    value={formData.name}
                    onChange={handleChange}
                />
            </div>

            <div className="mb-3">
                <label className="form-label">Créditos:</label>
                <input
                    type="number"
                    name="credits"
                    className="form-control"
                    value={formData.credits}
                    onChange={handleChange}
                />
            </div>

            <button type="submit" className="btn btn-primary">
                Guardar
            </button>
        </form>
    );
}

CourseForm.propTypes = {
    initialValues: PropTypes.shape({
        code: PropTypes.string,
        name: PropTypes.string,
        credits: PropTypes.number
    }).isRequired,
    onSubmit: PropTypes.func.isRequired
};

export default CourseForm;
