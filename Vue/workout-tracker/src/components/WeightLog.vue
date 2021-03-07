<template>
    <div class="container-fluid mt-4">
        <h1 class="h1">Weight Log</h1>
        <b-alert :show="loading" variant="info">One Sec...</b-alert>
        <b-row>
            <b-col>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Date Time</th>
                            <th>Weight</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="record in records" :key="record.id">
                            <td>{{ record.id }}</td>
                            <td>{{ record.dateTime }}</td>
                            <td>{{ record.weight }}</td>
                            <td class="text-right">
                                <a href="#" @click.prevent="updateWeightLog(record)">Edit</a>
                                <a href="#" @click.prevent="deleteWeightLog(record.id)">Delete</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </b-col>
            <b-col lg="2">
                <b-card :title="(model.id ? 'Edit Entry ID#' + model.id : 'New Weight Log')">
                    <form @submit.prevent="createWeightLog">
                        <b-form-group label="Date Time">
                            <b-form-input rows="4" v-model="model.dateTime" type="datetime-local"></b-form-input>
                        </b-form-group>
                        <b-form-group label="Weight">
                            <b-form-input v-model="model.weight" type="number"></b-form-input>
                        </b-form-group>
                        <div>
                            <b-btn type="submit" variant="success">Save Entry</b-btn>
                        </div>
                    </form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
import api from '@/TrackerApi';

export default {
    data() {
        return {
            loading: false,
            records: [],
            model: {}
        };
    },
    async created() {
        this.getAll()
    },
    methods: {
        async getAll() {
            this.loading = true

            try {
                this.records = await api.getAll()
            } finally {
                this.loading = false
            }
        },
        async updateWeightLog(weightLog) {
            this.model = Object.assign({}, weightLog)
        },
        async createWeightLog() {
            const isUpdate = !!this.model.id;

            if (isUpdate) {
                await api.update(this.model.id, this.model)
            } else {
                await api.create(this.model)
            }

            this.model = {}

            await this.getAll()
        },
        async deleteWeightLog(id) {
            if (confirm('Do you want to delete this entry?')) {
                if (this.model.id === id) {
                    this.model = {}
                }

                await api.delete(id)
                await this.getAll()
            }
        }
    }
}
</script>