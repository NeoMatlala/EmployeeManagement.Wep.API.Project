<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="text-center font-medium text-6xl mb-16">Dashboard</h1>
        <ul v-for="department in departments">
            <li>{{ department.departmentName }} - {{ department.manager }}</li>
        </ul>
    </div>
    
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
        departments: []
        };
    },
    created(){
    this.fetchDepartments();
    },
    methods: {
        async fetchDepartments() {
            try{
                const response = await axios.get('https://localhost:7244/api/Department/GetDepartments');
                console.log(response.data);
                this.departments = response.data
            } catch(error) {
                console.error('Error fetching departments:', error.message);
            }
        }
    }
}

</script>