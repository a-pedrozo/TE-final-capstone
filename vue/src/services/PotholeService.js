import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315/"
});

export default{
    getPotholes() {
        return http.get('pothole');
    },
    deletePothole(potholeId) {
        return http.delete('pothole/' + potholeId)
    },
    getPothole(potholeId) {
        return http.get('pothole/' + potholeId)
    },
    reportPothole(newPothole){
        return http.post('pothole', newPothole);
    }
}