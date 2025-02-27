import apiClient from "./apiClient";

export const getCourses = async () => {
    const response = await apiClient.get("/course");
    return response.data;
};

export const getCourseById = async (id) => {
    const response = await apiClient.get(`/course/${id}`);
    return response.data;
};

export const createCourse = async (course) => {
    const response = await apiClient.post("/course", course);
    return response.data;
};

export const updateCourse = async (id, course) => {
    await apiClient.put(`/course/${id}`, course);
};

export const deleteCourse = async (id) => {
    await apiClient.delete(`/course/${id}`);
};
