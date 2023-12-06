<template>
    <div class="max-w-7xl mx-auto">
        <h1 class="text-center font-medium text-6xl mb-16">Dashboard</h1>

        <div class="mt-10 flex justify-center items-center gap-16">
            <a href="#" class="block max-w-[200px] p-6 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">56</h5>
                <p class="font-normal text-gray-700 dark:text-gray-400">Departments</p>
            </a>
            <NuxtLink to="/departments" class="block max-w-[200px] p-6 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{{count}}</h5>
                <p class="font-normal text-gray-700 dark:text-gray-400">Departments</p>
            </NuxtLink>
        </div>
    </div>
    
</template>

<script>
import axios from 'axios';

export default{
    data() {
        return {
        count: 0,
        };
    },
    created(){
    this.fetchDepartmentsCount();
    },
    methods: {
        async fetchDepartmentsCount() {
            try{
                const response = await axios.get('https://localhost:7244/api/Department/GetDepartments');
                this.count = response.data.length
            } catch(error) {
                console.error('Error fetching departments:', error.message);
            }
        }
    }
}

</script>