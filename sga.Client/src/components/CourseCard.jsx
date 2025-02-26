import PropTypes from "prop-types";

function CourseCard({ course }) {
    return (
        <div className="course-card">
            <h3>{course.code} - {course.name}</h3>
            <p>{course.credits} Créditos</p>
        </div>
    );
}

// Validación de propiedades esperadas
CourseCard.propTypes = {
    course: PropTypes.shape({
        code: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        credits: PropTypes.number.isRequired,
    }).isRequired,
};

export default CourseCard;
