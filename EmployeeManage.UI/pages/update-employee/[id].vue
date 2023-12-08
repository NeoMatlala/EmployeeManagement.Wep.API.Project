<template>
    <div>
        <h1 class="font-medium text-3xl text-slate-800 mb-16">Edit Employee</h1>

        <form class="mt-16" @submit.prevent="handleUpdate">
            <div class="grid gap-10 mb-6 md:grid-cols-2">
                <div>
                    <label for="first_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input type="text" id="first_name" v-model="employee.name" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="John" required>
                    <small class="text-xs hidden text-red-600">Name is required</small>
                </div>
                <div>
                    <label for="last_name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Surname</label>
                    <input type="text" id="last_name" v-model="employee.surname" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Doe" required>
                    <small class="text-xs hidden text-red-600">Manager is required</small>
                </div>
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">ID Number</label>
                    <input type="text" id="company" v-model="employee.idNumber" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="7458963652144" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Job Title</label>
                    <input type="text" id="company" v-model="employee.jobTitle" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Senior Software Engineer" required>
                </div>  
                <div>
                    <label for="company" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Department Name</label>
                    <input type="text" id="company" v-model="employee.departmentName" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Software Development" required>
                </div>  
            </div>
            <div class="flex justify-end items-center">
                <button type="submit" class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">Update department</button>
                <NuxtLink to="/employees" data-modal-hide="default-modal" type="button" class="ms-3 text-gray-500 bg-gray-50 hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg border border-gray-200 text-sm font-medium px-5 py-2.5 hover:text-gray-900 focus:z-10">Cancel</NuxtLink>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue';
import { useRoute } from 'vue-router';

export default{
    data() {
        return {
            employee: {
                name: '',
                surname: '',
                idNumber: '',
                jobTitle: '',
                departmentName: '',
            }
        }
    },
    setup(){
        const id = ref(useRoute().params.id);
        return {
            id,
        };
    },
    created() {
        this.fetchEmployee()
    },
    methods: {
        async fetchEmployee() {
            try {
                var response = await axios.get(`https://localhost:7244/api/Employee/${this.id}`)
                //console.log(response.data)
                this.employee = response.data
            } catch (error) {
                console.log("Error getting employee: ", error.message)
            }
        },
        async handleUpdate() {
            try {
                var response = await axios.put(`https://localhost:7244/api/Employee/${this.id}`, this.employee)
                console.log(response.data)
                this.$router.replace('/employees');
            } catch (error) {
                console.log("Error updating employee: ", error.message)
            }
        }
    }
}
</script>