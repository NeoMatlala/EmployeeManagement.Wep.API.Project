<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Dashboard</h1>

        <div class="mt-10 flex justify-start items-center gap-10">
            <NuxtLink to="/employees" class="block max-w-[200px] p-16 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-5xl font-bold tracking-tight text-gray-900">{{employeeCount}}</h5>
                <p class="font-normal text-gray-700">Employees</p>
            </NuxtLink>
            <NuxtLink to="/departments" class="block max-w-[200px] p-16 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-5xl font-bold tracking-tight text-gray-900">{{departmentCount}}</h5>
                <p class="font-normal text-gray-700">Departments</p>
            </NuxtLink>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
        departmentCount: 0,
        employeeCount: 0,
        };
    },
    setup(){
        const config = useRuntimeConfig()
        return {
            baseApi : config.public.apiBase
        } 
    },
    created(){
        this.fetchDepartmentsCount();
        this.fetchEmployeeCount();
    },
    methods: {
        async fetchDepartmentsCount() {
            try{
                const response = await axios.get(`${this.baseApi}/api/Department/GetDepartments`);
                this.departmentCount = response.data.length
            } catch(error) {
                console.error('Error fetching departments:', error.message);
            }
        },
        async fetchEmployeeCount(){
            try{
                var response = await axios.get(`${this.baseApi}/api/Employee`)
                this.employeeCount = response.data.length
            } catch(error){
                console.log("Error getting employee count:", error.message)
            }
        }
    }
}

</script>