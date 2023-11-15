var MongoClient = require("mongodb").MongoClient;
var connect = require("./connect"); //url from connect module
var client = new MongoClient(connect.database.url, {
    useUnifiedTopology: true,
});

var dbName = "Beers_Criteria"; //Database name

//2023 American Geriatrics Society Beers Criteria® for potentially inappropriate medications: drugs to be used with caution in older adults.
async function insertMed(db) {
    var collection = db.collection('Table4');
    var userObjects1 = [
        {
            ID: 1,
            Drug_Names: 'Dabigatran for long-term treatment of nonvalvular atrial fibrillation or venous thromboembolism (VTE)',
            Rationale: 'Increased risk of GI bleeding compared with warfarin (based on head-to-head clinical trials) and of GI bleeding and major bleeding compared with apixaban (based on observational studies and meta-analyses) in older adults when used for long-term treatment of nonvalvular atrial fibrillation or VTE.',
            Recommendation: 'Use caution in selecting dabigatran over other DOACs (e.g., apixaban) for long term treatment of nonvalvular atrial fibrillation or VTE.\nSee also criteria on warfarin and rivaroxaban (Table 2) and footnoted regarding choice among DOACs.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 2,
            Drug_Names: ['Prasugrel','Ticagrelor'],
            Rationale: 'Both increase the risk of major bleeding in older adults compared with clopidogrel, especially among those 75 years old and older. However, this risk may be offset by cardiovascular benefits in select patients.',
            Recommendation: 'Use with caution, particularly in adults 75 years old and older.\nIf prasugrel is used, consider a lower dose (5 mg) for those 75 years old and older.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 3,
            Drug_Names:
                [{
                    'Antidepressants (selected)': ['Mirtazipine', 'SNRIs', 'SSRIs', 'TCAs'],
                    'Antiepileptics (selected)':['Carbamazepine', 'Oxcarbazepine'],
                    'Antipsychotics':'',
                    'Diuretics': '',
                    'Tramadol':'',
                }],
            Rationale: 'May exacerbate or cause SIADH or hyponatremia; monitor sodium levels closely when starting or changing dosages in older adults.',
            Recommendation: 'Use with caution',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 4,
            Drug_Names:'Dextromethorphan-quinidine',
            Rationale:'Limited efficacy in patients with behavioral symptoms of dementia (does not apply to the treatment of pseudobulbar affect). May increase the risk of falls and concerns with clinically significant drug interactions and with use in those with heart failure (see Table 3).',
            Recommendation: 'Use with caution',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 5,
            Drug_Names:'Trimethoprim-sulfamethoxazole',
            Rationale: 'Increased risk of hyperkalemia when used concurrently with an ACEI, ARB, or ARNI in presence of decreased CrCl.',
            Recommendation: 'Use with caution in patients on ACEI, ARB, or ARNI and decreased CrCl.',
            Quality_of_Evidence: 'Low',
            Strength_of_Recommendation: 'Strong',
        },
        {
            ID: 6,
            Drug_Names:
                [{
                    'Sodium-glucose co-transporter-2 (SGLT2) inhibitors': ['Canigliflozin','Dapagliflozin', 'Emplaglifozin', 'Ertuglifozin']
                }],
            Rationale: 'Older adults may be at increased risk of urogenital infections, particularly women in the first month of treatment. An increased risk of euglycemic diabetic ketoacidosis has also been seen in older adults.',
            Recommendation: 'Use with caution\nMonitor patients for urogenital infections and ketoacidosis.',
            Quality_of_Evidence: 'Moderate',
            Strength_of_Recommendation: 'Weak',
        },
    ];

    try {
        await collection.insertMany(userObjects1);
        console.log("Medications List Created!");
    } catch (err) {
        console.error("Failed to insert document:", err);
        throw err; // Propagate the error
    }
}

async function main() {
    try {
        await client.connect();
        console.log("Connected successfully to server");
        var db = client.db(dbName); //Use this database

        await insertMed(db);
    } catch (err) {
        console.error("Failed to connect to the server:", err);
    } finally {
        await client.close();
    }
}

main();
