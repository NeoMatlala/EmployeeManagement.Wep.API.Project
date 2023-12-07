<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Dashboard</h1>

        <div class="mt-10 flex justify-start items-center gap-10">
            <a href="#" class="block max-w-[200px] p-16 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-5xl font-bold tracking-tight text-gray-900 dark:text-white">56</h5>
                <p class="font-normal text-gray-700 dark:text-gray-400">Employees</p>
            </a>
            <NuxtLink to="/departments" class="block max-w-[200px] p-16 bg-white border border-gray-200 rounded-lg hover:bg-gray-100">
                <h5 class="mb-2 text-5xl font-bold tracking-tight text-gray-900 dark:text-white">{{count}}</h5>
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