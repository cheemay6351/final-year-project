var MongoClient = require("mongodb").MongoClient;
var connect = require("../connect"); // url from connect module
var client = new MongoClient(connect.database.url, {
    useUnifiedTopology: true,
});

var dbName = "Beers_Criteria"; // database name

// used javascript as initial language for manual insertion of data
// 2023 American Geriatrics Society Beers Criteria® for potentially inappropriate medication use in older adults due to drug–disease or drug–syndrome interactions that may exacerbate the disease or syndrome.
async function insertMed(db) {
    var collection = db.collection('Table3');
    var userObjects1 = [
        {
            ID: 1,
            Disease_Category: 'Cardiovascular',
            Disease_Syndrome: 'Heart failure',
            Drug_Names:
                [{
                    'Cilostazol': '',
                    'Dextromethorphan-quinidine': '',
                    'Nondihydropyridine calcium channel blockers (CCBs)': ['Diltiazem', 'Verapamil'],
                    'Dronedarone': '',
                    'NSAIDs and COX-2 inhibitors': '',
                    'Thiazolidinediones': 'Pioglitazone',
                }],
            Rationale: 'Potential to promote fluid retention and/or exacerbate heart failure (NSAIDs and COX-2 inhibitors, non-dihydropyridine CCBs, thiazolidinediones); potential to increase mortality in older adults with heart failure (cilostazol and dronedarone); concerns about QT prolongation (dextromethorphan-quinidine).\nNote: This is not a comprehensive list of medications to avoid in patients with heart failure.',
            Recommendation:
                [{
                    'Avoid': ["Cilostazol", "Dextromethorphan-quinidine"],
                    'Avoid in heart failure with reduced ejection fraction': { 'Nondihydropyridine calcium channel blockers (CCBs)': ['Diltiazem', 'Verapamil'] },
                    'Use with caution in patients with heart failure who are asymptomatic; avoid in patients with symptomatic heart failure': ['Dronedarone', 'NSAIDs and COX-2 inhibitors', { 'Thiazolidinediones': 'Pioglitazon' },]
                }],
            Quality_of_Evidence: ['Cilostazol, dextromethorphan-quinidine, COX-2 inhibitors: Low', 'Non-dihydropyridine CCBs, NSAIDs: Moderate', 'Dronedarone, thiazolidenediones: High'],
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 2,
            Disease_Category: 'Cardiovascular',
            Disease_Syndrome: 'Syncope',
            Drug_Names:
                [{
                    'Antipsychotics (selected)': ['Chlorpromazine', 'Olanzapine'],
                    'Cholinesterase inhibitors (AChEIs)': ['Donepezil', 'Galantamine', 'Rivastigmine'],
                    'Non-selective peripheral alpha-1 blockers': ['Doxazosin', 'Prazosin', 'Terazosin'],
                    'Tertiary tricyclic antidepressants (TCAs)': ['Amitriptyline', 'Clomipramine', 'Doxepin', 'Imipramine'],
                }],
            Rationale: 'Antipsychotics listed and tertiary TCAs increase the risk of orthostatic hypotension.\nAChEIs cause bradycardia and should be avoided in older adults whose syncope may be due to bradycardia.\nNon-selective peripheral alpha-1 blockers cause orthostatic blood pressure changes and should be avoided in older adults whose syncope may be due to orthostatic hypotension.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: ['Antipsychotics, non-selective peripheral alpha-1 blockers: Weak', 'AChEIs, tertiary TCAs: Strong'],
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 3,
            Disease_Category: 'Central nervous system',
            Disease_Syndrome: 'Delirium',
            Drug_Names:
                [{
                    'Anticholinergics (see Table 7)': '',
                    'Antipsychoticsc': '',
                    'Benzodiazepines': '',
                    'Corticosteroids (oral and parenteral)': '',
                    'H2-receptor antagonists': ['Cimetidine', 'Famotidine', 'Nizatidine'],
                    'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (“Z-drugs”)': ['Eszopiclone', 'Zaleplon', 'Zolpidem'],
                    'Opioids': '',
                }],
            Rationale: 'Avoid in older adults with or at high risk of delirium because of the potential of inducing or worsening delirium.\nAntipsychotics: avoid for behavioral problems of dementia or delirium unless nonpharmacologic options (eg, behavioral interventions) have failed or are not possible and the older adult is threatening substantial harm to self or others. If used, periodic deprescribing attempts should be considered to assess ongoing need and/or the lowest effective dose.\nCorticosteroids: if needed, use the lowest possible dose for the shortest duration and monitor for delirium.\nOpioids: emerging data highlights an association between opioid administration and delirium. For older adults with pain, use a balanced approach, including the use of validated pain assessment tools and multimodal strategies that include nondrug approaches to minimize opioid use.',
            Recommendation: 'Avoid, except in situations listed under the rationale statement.',
            Quality_of_Evidence: ['H2-receptor antagonists: Low', 'All others: Moderate'],
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 4,
            Disease_Category: 'Central nervous system',
            Disease_Syndrome: 'Dementia or cognitive impairment',
            Drug_Names:
                [{
                    'Anticholinergics (see Table 7)': '',
                    'Antipsychotics, chronic use or persistent as-needed use': '',
                    'Benzodiazepines': '',
                    'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (“Z-drugs”)': ['Eszopiclone', 'Zaleplon', 'Zolpidem'],
                }],
            Rationale:'Avoid because of adverse CNS effects. See criteria on individual drugs for additional information.\nAntipsychotics: increased risk of stroke and greater rate of cognitive decline and mortality in people with dementia. Avoid antipsychotics for behavioral problems of dementia or delirium unless documented nonpharmacologic options (e.g., behavioral interventions) have failed and/or the patient is threatening substantial harm to self or others. If used, periodic deprescribing attempts should be considered to assess ongoing need and/or the lowest effective dose.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 5,
            Disease_Category: 'Central nervous system',
            Disease_Syndrome: 'History of falls or fractures',
            Drug_Names:
                [{
                    'Anticholinergics (see Table 7)': '',
                    'Antidepressants (selected classes)': ['SNRIs', 'SSRIs', 'Tricyclic antidepressants (TCAs)'],
                    'Antiepileptics': '',
                    'Antipsychoticsc': '',
                    'Benzodiazepines': '',
                    'Nonbenzodiazepine benzodiazepine receptor agonist hypnotics (“Z-drugs”)': ['Eszopiclone', 'Zaleplon', 'Zolpidem'],
                    'Opioids': '',
                }],
            Rationale: 'May cause ataxia, impaired psychomotor function, syncope, or additional falls.\nAntidepressants (selected classes): evidence for risk of falls and fractures is mixed; newer evidence suggests that SNRIs may increase falls risk.\nBenzodiazepines: shorter-acting ones are not safer than long-acting ones.\nIf one of the drugs must be used, consider reducing the use of other CNS-active medications that increase the risk of falls and fractures',
            Recommendation: 'Avoid unless safer alternatives are not available.\nAntiepileptics: avoid except for seizures and mood disorders.\nOpioids: avoid except for pain management in the setting of severe acute pain.',
            Quality_of_Evidence: ['Antidepressants, opioids: Moderate', 'All others: High'],
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 6,
            Disease_Category: 'Central nervous system',
            Disease_Syndrome: 'Parkinson disease',
            Drug_Names:
                [{
                    'Antiemetics': ['Metoclopramide', 'Prochlorperazine', 'Promethazine'],
                    'Antipsychotics (except clozapine, pimavanserin, and quetiapine)': '',
                }],
            Rationale: 'Dopamine-receptor antagonists with the potential to worsen parkinsonian symptoms\nExceptions: clozapine, pimavanserin, and quetiapine appear to be less likely to precipitate the worsening of Parkinson disease than other antipsychotics.',
            Recommendation: 'Avoid',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 7,
            Disease_Category: 'Gastrointestinal',
            Disease_Syndrome: 'History of gastric or duodenal ulcers',
            Drug_Names: ['Aspirin', 'Non-COX-2 selective NSAIDs'],
            Rationale: 'May exacerbate existing ulcers or cause new/additional ulcers',
            Recommendation: 'Avoid unless other alternatives are not effective and the patient can take a gastroprotective agent (i.e., proton-pump inhibitor or misoprostol).',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 8,
            Disease_Category: 'Kidney/urinary tract',
            Disease_Syndrome: 'Urinary incontinence (all types) in women',
            Drug_Names:
                [{
                    'Non-selective peripheral alpha-1 blockers': ['Doxazosin', 'Prazosin', 'Terazosin'],
                    'Estrogen, oral and transdermal (excludes intravaginal estrogen)': '',
                }],
            Rationale: 'Aggravation of incontinence (alpha-1 blockers), lack of efficacy (oral estrogen)',
            Recommendation: 'Avoid in women\nSee also recommendation on estrogen (Table 2)',
            Quality_of_Evidence: ['Non-selective alpha-1 blockers: Moderate', 'Estrogen: High'],
            Strength_of_Recommendation: ['Non-selective peripheral alpha-1 blockers: Strong', 'Estrogen: Strong'],
        },
        {
            ID: 9,
            Disease_Category: 'Kidney/urinary tract',
            Disease_Syndrome: 'Lower urinary tract symptoms, benign prostatic hyperplasia',
            Drug_Names: 'Strongly anticholinergic drugs, except antimuscarinics for urinary incontinence (see Table 7)',
            Rationale: 'May decrease urinary flow and cause urinary retention',
            Recommendation: 'Avoid in men',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
    ];

    try {
        await collection.insertMany(userObjects1);
        console.log("Medications List Created!");
    } catch (err) {
        console.error("Failed to insert document:", err);
        throw err; //  propagate the error
    }
}

async function main() {
    try {
        await client.connect();
        console.log("Connected successfully to server");
        var db = client.db(dbName); // use this database

        await insertMed(db);
    } catch (err) {
        console.error("Failed to connect to the server:", err);
    } finally {
        await client.close();
    }
}

main();
